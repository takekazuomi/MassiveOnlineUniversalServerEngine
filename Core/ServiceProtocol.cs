﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;
using NLog;
using System.Reflection;

namespace MOUSE.Core
{
    public interface IServiceProtocol
    {
        Task<Message> Dispatch(object target, Message msg);
        void DispatchOneWay(object target, Message msg);
        NodeServiceProxy CreateProxy(NodeServiceKey serviceKey, IMessageFactory messageFactory, IServiceOperationDispatcher dispatcher);

        NodeServiceKey GetKey<TServiceContract>(uint serviceId = 0);
        uint GetContractId(Type contractType);
        bool TryGetContractId(Type contractType, out uint typeId);
        Type GetContractType(uint serviceTypeId);
        NodeServiceContractDescription GetDescription(uint serviceTypeId);
    }

    public class ServiceProtocol : IServiceProtocol
    {
        Logger Log = LogManager.GetCurrentClassLogger();

        private readonly Dictionary<uint, NodeServiceContractDescription> _descByTypeId = new Dictionary<uint, NodeServiceContractDescription>();
        private readonly Dictionary<uint, Func<IMessageFactory, object, Message, Task<Message>>> _dispatcherByMsgId = new Dictionary<uint, Func<IMessageFactory, object, Message, Task<Message>>>();
        private readonly Dictionary<Type, uint> _serviceTypeIdByContractType = new Dictionary<Type, uint>();
        private readonly IMessageFactory _messageFactory;

        public ServiceProtocol(IMessageFactory msgfactory, IEnumerable<NodeServiceProxy> importedProxies)
        {
            Contract.Requires(importedProxies != null);
            Contract.Requires(msgfactory != null);

            _messageFactory = msgfactory;

            foreach (var proxy in importedProxies)
            {
                Type type = proxy.GetType();
                if (type.ContainsAttribute<NetProxyAttribute>())
                {
                    var proxyAttr = type.GetAttribute<NetProxyAttribute>();
                    var contractAttr = proxyAttr.ContractType.GetAttribute<NetContractAttribute>();

                    var operations = new List<NodeServiceOperationDescription>();
                    foreach (var method in type.GetMethods().Where(x => x.ContainsAttribute<NetOperationDispatcherAttribute>()))
                    {
                        var opAttr = method.GetAttribute<NetOperationDispatcherAttribute>();
                        Message request = (Message)FormatterServices.GetUninitializedObject(opAttr.RequestMessage);
                        uint? replyId = null;
                        if (opAttr.ReplyMessage != null)
                            replyId = ((Message)FormatterServices.GetUninitializedObject(opAttr.ReplyMessage)).Id;
                        var opDesc = new NodeServiceOperationDescription(
                            method.Name, request.Id, replyId, (Func<IMessageFactory, object, Message, Task<Message>>)Delegate.CreateDelegate(
                                                                            typeof(Func<IMessageFactory, object, Message, Task<Message>>), method));
                        operations.Add(opDesc);
                    }

                    var desc = new NodeServiceContractDescription(proxyAttr.ContractTypeId,
                        proxyAttr.ContractType, type, contractAttr, operations);
                    RegisterService(desc);

                }
            }
        }

        
        public void RegisterService(NodeServiceContractDescription desc)
        {
            Contract.Requires(desc != null);

            _descByTypeId.Add(desc.TypeId, desc);
            _serviceTypeIdByContractType.Add(desc.ContractType, desc.TypeId);

            foreach (var operation in desc.Operations)
                _dispatcherByMsgId.Add(operation.RequestMessageId, operation.Dispatch);

            Log.Info("Registered Entity<contractType:{0}, typeId:{1}>", desc.ContractType, desc.TypeId);
        }

        public Task<Message> Dispatch(object service, Message msg)
        {
            Contract.Requires(service != null);
            Contract.Requires(msg != null);
            Contract.Ensures(Contract.Result<Message>() != null);

            Func<IMessageFactory, object, Message, Task<Message>> dispatch;
            if (_dispatcherByMsgId.TryGetValue(msg.Id, out dispatch))
                return dispatch(_messageFactory, service, msg);
            else
            {
                var tcs = new TaskCompletionSource<Message>();
                tcs.SetResult(new InvalidOperation((ushort)BasicErrorCode.DispatcherNotFound, "Dispatcher not found for MsgId:"+msg.Id));
                return tcs.Task;
            }
        }

        public void DispatchOneWay(object service, Message msg)
        {
            Contract.Requires(service != null);
            Contract.Requires(msg != null);

            Func<IMessageFactory, object, Message, Task<Message>> dispatch;
            if (_dispatcherByMsgId.TryGetValue(msg.Id, out dispatch))
                dispatch(_messageFactory, service, msg);
        }

        public NodeServiceProxy CreateProxy(NodeServiceKey serviceKey, IMessageFactory messageFactory, IServiceOperationDispatcher dispatcher)
        {
            NodeServiceProxy proxy;
            NodeServiceContractDescription desc;
            if (_descByTypeId.TryGetValue(serviceKey.TypeId, out desc))
            {
                proxy = (NodeServiceProxy)FormatterServices.GetUninitializedObject(desc.ProxyType);
                proxy.Init(serviceKey, desc, messageFactory, dispatcher);
            }
            else
                throw new Exception("Unregistered entity typeId - " + serviceKey.TypeId);
            
            return proxy;
        }

        public NodeServiceKey GetKey<ServiceContract>(uint serviceId = 0)
        {
            uint typeId;
            if (_serviceTypeIdByContractType.TryGetValue(typeof(ServiceContract), out typeId))
                return new NodeServiceKey(typeId, serviceId);
            else
                throw new Exception("Unregistered service cotract - " + typeof(ServiceContract).FullName);
        }

        public uint GetContractId(Type contractType)
        {
            uint typeId;
            if (_serviceTypeIdByContractType.TryGetValue(contractType, out typeId))
                return typeId;
            else
                throw new Exception("Unregistered entity cotract - " + contractType.FullName);
        }

        public bool TryGetContractId(Type contractType, out uint typeId)
        {
            return _serviceTypeIdByContractType.TryGetValue(contractType, out typeId);
        }

        public Type GetContractType(uint serviceTypeId)
        {
            NodeServiceContractDescription desc;
            if (_descByTypeId.TryGetValue(serviceTypeId, out desc))
                return desc.ContractType;
            else
                return null;
        }

        public NodeServiceContractDescription GetDescription(uint typeId)
        {
            NodeServiceContractDescription desc;
            if (_descByTypeId.TryGetValue(typeId, out desc))
                return desc;
            else
                return null;
        }

    }

    public enum BasicErrorCode
    {
        DispatcherNotFound
    }
}
