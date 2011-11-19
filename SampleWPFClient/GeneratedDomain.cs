﻿using MOUSE.Core;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Runtime.Serialization;

namespace Protocol.Generated
{
    [Export(typeof(NodeServiceProxy))]
    [NetProxy(ContractTypeId = 1279047273, ContractType = typeof(SampleC2SProtocol.IChatLogin))]
    public sealed class IChatLoginProxy : NodeServiceProxy, SampleC2SProtocol.IChatLogin
    {
        public async Task< SampleC2SProtocol.LoginResult > Login ( string name )
        {
            var request = Node.MessageFactory.New< IChatLoginLoginRequest >();
            request.name=name;
            Message reply = await Node.ExecuteServiceOperation(this, request);
            var ret = ((IChatLoginLoginReply)reply).RetVal;
            Node.MessageFactory.Free(reply);
            Node.MessageFactory.Free(request);
            return ret;
        }
        [NetOperationDispatcher(RequestMessage = typeof(IChatLoginLoginRequest), ReplyMessage = typeof(IChatLoginLoginReply))]
        public static async Task<Message> Login(IMessageFactory msgFactory, object target, Message input)
        {
            var msg = (IChatLoginLoginRequest)input;
            var retVal = await ((SampleC2SProtocol.IChatLogin)target).Login(msg.name);
            var retMsg = msgFactory.New<IChatLoginLoginReply>();
            retMsg.RetVal = retVal;
            return retMsg;
        }
    }
    [Export(typeof(NodeServiceProxy))]
    [NetProxy(ContractTypeId = 4131147598, ContractType = typeof(SampleC2SProtocol.IChatService))]
    public sealed class IChatServiceProxy : NodeServiceProxy, SampleC2SProtocol.IChatService
    {
        public async Task< System.Collections.Generic.List<SampleC2SProtocol.ChatRoomInfo> > GetRooms (  )
        {
            var request = Node.MessageFactory.New< IChatServiceGetRoomsRequest >();
            Message reply = await Node.ExecuteServiceOperation(this, request);
            var ret = ((IChatServiceGetRoomsReply)reply).RetVal;
            Node.MessageFactory.Free(reply);
            Node.MessageFactory.Free(request);
            return ret;
        }
        [NetOperationDispatcher(RequestMessage = typeof(IChatServiceGetRoomsRequest), ReplyMessage = typeof(IChatServiceGetRoomsReply))]
        public static async Task<Message> GetRooms(IMessageFactory msgFactory, object target, Message input)
        {
            var msg = (IChatServiceGetRoomsRequest)input;
            var retVal = await ((SampleC2SProtocol.IChatService)target).GetRooms();
            var retMsg = msgFactory.New<IChatServiceGetRoomsReply>();
            retMsg.RetVal = retVal;
            return retMsg;
        }
        public async Task< SampleC2SProtocol.CreateRoomResponse > CreateRoom ( string roomName )
        {
            var request = Node.MessageFactory.New< IChatServiceCreateRoomRequest >();
            request.roomName=roomName;
            Message reply = await Node.ExecuteServiceOperation(this, request);
            var ret = ((IChatServiceCreateRoomReply)reply).RetVal;
            Node.MessageFactory.Free(reply);
            Node.MessageFactory.Free(request);
            return ret;
        }
        [NetOperationDispatcher(RequestMessage = typeof(IChatServiceCreateRoomRequest), ReplyMessage = typeof(IChatServiceCreateRoomReply))]
        public static async Task<Message> CreateRoom(IMessageFactory msgFactory, object target, Message input)
        {
            var msg = (IChatServiceCreateRoomRequest)input;
            var retVal = await ((SampleC2SProtocol.IChatService)target).CreateRoom(msg.roomName);
            var retMsg = msgFactory.New<IChatServiceCreateRoomReply>();
            retMsg.RetVal = retVal;
            return retMsg;
        }
        public async Task< long > JoinRoom ( uint roomId )
        {
            var request = Node.MessageFactory.New< IChatServiceJoinRoomRequest >();
            request.roomId=roomId;
            Message reply = await Node.ExecuteServiceOperation(this, request);
            var ret = ((IChatServiceJoinRoomReply)reply).RetVal;
            Node.MessageFactory.Free(reply);
            Node.MessageFactory.Free(request);
            return ret;
        }
        [NetOperationDispatcher(RequestMessage = typeof(IChatServiceJoinRoomRequest), ReplyMessage = typeof(IChatServiceJoinRoomReply))]
        public static async Task<Message> JoinRoom(IMessageFactory msgFactory, object target, Message input)
        {
            var msg = (IChatServiceJoinRoomRequest)input;
            var retVal = await ((SampleC2SProtocol.IChatService)target).JoinRoom(msg.roomId);
            var retMsg = msgFactory.New<IChatServiceJoinRoomReply>();
            retMsg.RetVal = retVal;
            return retMsg;
        }
    }
    [Export(typeof(NodeServiceProxy))]
    [NetProxy(ContractTypeId = 2616972471, ContractType = typeof(SampleC2SProtocol.IChatRoomService))]
    public sealed class IChatRoomServiceProxy : NodeServiceProxy, SampleC2SProtocol.IChatRoomService
    {
        public async Task< System.Collections.Generic.List<string> > Join ( long ticket )
        {
            var request = Node.MessageFactory.New< IChatRoomServiceJoinRequest >();
            request.ticket=ticket;
            Message reply = await Node.ExecuteServiceOperation(this, request);
            var ret = ((IChatRoomServiceJoinReply)reply).RetVal;
            Node.MessageFactory.Free(reply);
            Node.MessageFactory.Free(request);
            return ret;
        }
        [NetOperationDispatcher(RequestMessage = typeof(IChatRoomServiceJoinRequest), ReplyMessage = typeof(IChatRoomServiceJoinReply))]
        public static async Task<Message> Join(IMessageFactory msgFactory, object target, Message input)
        {
            var msg = (IChatRoomServiceJoinRequest)input;
            var retVal = await ((SampleC2SProtocol.IChatRoomService)target).Join(msg.ticket);
            var retMsg = msgFactory.New<IChatRoomServiceJoinReply>();
            retMsg.RetVal = retVal;
            return retMsg;
        }
        public void Say ( string message )
        {
            var request = Node.MessageFactory.New< IChatRoomServiceSayRequest >();
            request.message=message;
            Node.ExecuteServiceOperation(this, request);
            Node.MessageFactory.Free(request);
        }
        [NetOperationDispatcher(RequestMessage = typeof(IChatRoomServiceSayRequest), ReplyMessage = null)]
        public static async Task<Message> Say(IMessageFactory msgFactory, object target, Message input)
        {
            var msg = (IChatRoomServiceSayRequest)input;
            ((SampleC2SProtocol.IChatRoomService)target).Say(msg.message);
            return null;
        }
    }
    [Export(typeof(NodeServiceProxy))]
    [NetProxy(ContractTypeId = 3421052361, ContractType = typeof(SampleC2SProtocol.IChatRoomServiceCallback))]
    public sealed class IChatRoomServiceCallbackProxy : NodeServiceProxy, SampleC2SProtocol.IChatRoomServiceCallback
    {
        public void OnRoomMessage ( uint roomId, string message )
        {
            var request = Node.MessageFactory.New< IChatRoomServiceCallbackOnRoomMessageRequest >();
            request.roomId=roomId;
            request.message=message;
            Node.ExecuteServiceOperation(this, request);
            Node.MessageFactory.Free(request);
        }
        [NetOperationDispatcher(RequestMessage = typeof(IChatRoomServiceCallbackOnRoomMessageRequest), ReplyMessage = null)]
        public static async Task<Message> OnRoomMessage(IMessageFactory msgFactory, object target, Message input)
        {
            var msg = (IChatRoomServiceCallbackOnRoomMessageRequest)input;
            ((SampleC2SProtocol.IChatRoomServiceCallback)target).OnRoomMessage(msg.roomId, msg.message);
            return null;
        }
    }
    [Export(typeof(Message))]
    [DataContract]
    public sealed class IChatLoginLoginRequest : Message
    {
        [DataMember]
        public string name;

        public override uint Id
        {
            get { return 2019756658; }
        }

        public override void Serialize(NativeWriter w)
        {
            base.Serialize(w);
            w.WriteUnicode(name);
        }

        public override void Deserialize(NativeReader r)
        {
            base.Deserialize(r);
            name = r.ReadUnicode();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    [Export(typeof(Message))]
    [DataContract]
    public sealed class IChatLoginLoginReply : Message
    {
        [DataMember]
        public SampleC2SProtocol.LoginResult RetVal;

        public override uint Id
        {
            get { return 1128145376; }
        }

        public override void Serialize(NativeWriter w)
        {
            base.Serialize(w);
            w.Write(RetVal);
        }

        public override void Deserialize(NativeReader r)
        {
            base.Deserialize(r);
            RetVal = r.ReadInt32();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    [Export(typeof(Message))]
    [DataContract]
    public sealed class IChatServiceGetRoomsRequest : Message
    {

        public override uint Id
        {
            get { return 1938706274; }
        }

        public override void Serialize(NativeWriter w)
        {
            base.Serialize(w);
        }

        public override void Deserialize(NativeReader r)
        {
            base.Deserialize(r);
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    [Export(typeof(Message))]
    [DataContract]
    public sealed class IChatServiceGetRoomsReply : Message
    {
        [DataMember]
        public System.Collections.Generic.List<SampleC2SProtocol.ChatRoomInfo> RetVal;

        public override uint Id
        {
            get { return 1966421887; }
        }

        public override void Serialize(NativeWriter w)
        {
            base.Serialize(w);
            if(RetVal != null)
            {
                w.Write(true);
                w.Write((int)RetVal.Count);
                foreach(var element in RetVal)
                    ChatRoomInfoSerializer.Serialize(element, w);
            }
            else
                w.Write(false);
        }

        public override void Deserialize(NativeReader r)
        {
            base.Deserialize(r);
            {
                bool isNotNull = r.ReadBoolean();
                if(!isNotNull)
                    RetVal = null;
                else
                {
                    int lenght = r.ReadInt32();
                    var list = new List< SampleC2SProtocol.ChatRoomInfo >(lenght);
                    for(int i = 0; i < lenght; i++)
                    {
                        var x = ChatRoomInfoSerializer.Deserialize(r);
                        list.Add(x);
                    }
                    RetVal = list;
                }
            }
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    [Export(typeof(Message))]
    [DataContract]
    public sealed class IChatServiceCreateRoomRequest : Message
    {
        [DataMember]
        public string roomName;

        public override uint Id
        {
            get { return 646834541; }
        }

        public override void Serialize(NativeWriter w)
        {
            base.Serialize(w);
            w.WriteUnicode(roomName);
        }

        public override void Deserialize(NativeReader r)
        {
            base.Deserialize(r);
            roomName = r.ReadUnicode();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    [Export(typeof(Message))]
    [DataContract]
    public sealed class IChatServiceCreateRoomReply : Message
    {
        [DataMember]
        public SampleC2SProtocol.CreateRoomResponse RetVal;

        public override uint Id
        {
            get { return 1012128215; }
        }

        public override void Serialize(NativeWriter w)
        {
            base.Serialize(w);
            CreateRoomResponseSerializer.Serialize(RetVal, w);
        }

        public override void Deserialize(NativeReader r)
        {
            base.Deserialize(r);
            RetVal = CreateRoomResponseSerializer.Deserialize(r);
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    [Export(typeof(Message))]
    [DataContract]
    public sealed class IChatServiceJoinRoomRequest : Message
    {
        [DataMember]
        public uint roomId;

        public override uint Id
        {
            get { return 4139561538; }
        }

        public override void Serialize(NativeWriter w)
        {
            base.Serialize(w);
            w.Write(roomId);
        }

        public override void Deserialize(NativeReader r)
        {
            base.Deserialize(r);
            roomId = r.ReadUInt32();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    [Export(typeof(Message))]
    [DataContract]
    public sealed class IChatServiceJoinRoomReply : Message
    {
        [DataMember]
        public long RetVal;

        public override uint Id
        {
            get { return 693987992; }
        }

        public override void Serialize(NativeWriter w)
        {
            base.Serialize(w);
            w.Write(RetVal);
        }

        public override void Deserialize(NativeReader r)
        {
            base.Deserialize(r);
            RetVal = r.ReadInt64();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    [Export(typeof(Message))]
    [DataContract]
    public sealed class IChatRoomServiceJoinRequest : Message
    {
        [DataMember]
        public long ticket;

        public override uint Id
        {
            get { return 3112933142; }
        }

        public override void Serialize(NativeWriter w)
        {
            base.Serialize(w);
            w.Write(ticket);
        }

        public override void Deserialize(NativeReader r)
        {
            base.Deserialize(r);
            ticket = r.ReadInt64();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    [Export(typeof(Message))]
    [DataContract]
    public sealed class IChatRoomServiceJoinReply : Message
    {
        [DataMember]
        public System.Collections.Generic.List<string> RetVal;

        public override uint Id
        {
            get { return 4292680201; }
        }

        public override void Serialize(NativeWriter w)
        {
            base.Serialize(w);
            if(RetVal != null)
            {
                w.Write(true);
                w.Write((int)RetVal.Count);
                foreach(var element in RetVal)
                    w.WriteUnicode(element);
            }
            else
                w.Write(false);
        }

        public override void Deserialize(NativeReader r)
        {
            base.Deserialize(r);
            {
                bool isNotNull = r.ReadBoolean();
                if(!isNotNull)
                    RetVal = null;
                else
                {
                    int lenght = r.ReadInt32();
                    var list = new List< System.String >(lenght);
                    for(int i = 0; i < lenght; i++)
                    {
                        var x = r.ReadUnicode();
                        list.Add(x);
                    }
                    RetVal = list;
                }
            }
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    [Export(typeof(Message))]
    [DataContract]
    public sealed class IChatRoomServiceSayRequest : Message
    {
        [DataMember]
        public string message;

        public override uint Id
        {
            get { return 999376688; }
        }

        public override void Serialize(NativeWriter w)
        {
            base.Serialize(w);
            w.WriteUnicode(message);
        }

        public override void Deserialize(NativeReader r)
        {
            base.Deserialize(r);
            message = r.ReadUnicode();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    [Export(typeof(Message))]
    [DataContract]
    public sealed class IChatRoomServiceCallbackOnRoomMessageRequest : Message
    {
        [DataMember]
        public uint roomId;
        [DataMember]
        public string message;

        public override uint Id
        {
            get { return 673625236; }
        }

        public override void Serialize(NativeWriter w)
        {
            base.Serialize(w);
            w.Write(roomId);
            w.WriteUnicode(message);
        }

        public override void Deserialize(NativeReader r)
        {
            base.Deserialize(r);
            roomId = r.ReadUInt32();
            message = r.ReadUnicode();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
	
    public static class CreateRoomResponseSerializer	
    {
        public static void Serialize(SampleC2SProtocol.CreateRoomResponse x, NativeWriter w)
        {
            if(x == null)
            {
                w.Write(false);
                return;
            }
            w.Write(true);
            w.Write(x.Code);
            CreateRoomResponseSubDataSerializer.Serialize(x.Data, w);
        }
        
        public static SampleC2SProtocol.CreateRoomResponse Deserialize(NativeReader r)
        {
            {
                bool isNotNull = r.ReadBoolean();
                if(!isNotNull)
                    return null;
            }
            var ret = new SampleC2SProtocol.CreateRoomResponse();
            ret.Code = r.ReadInt32();
            ret.Data = CreateRoomResponseSubDataSerializer.Deserialize(r);
            return ret;
        }
    }
	
    public static class CreateRoomResponseSubDataSerializer	
    {
        public static void Serialize(SampleC2SProtocol.CreateRoomResponse.CreateRoomResponseSubData x, NativeWriter w)
        {
            if(x == null)
            {
                w.Write(false);
                return;
            }
            w.Write(true);
            w.Write(x.RoomId);
            w.Write(x.Ticket);
        }
        
        public static SampleC2SProtocol.CreateRoomResponse.CreateRoomResponseSubData Deserialize(NativeReader r)
        {
            {
                bool isNotNull = r.ReadBoolean();
                if(!isNotNull)
                    return null;
            }
            var ret = new SampleC2SProtocol.CreateRoomResponse.CreateRoomResponseSubData();
            ret.RoomId = r.ReadUInt32();
            ret.Ticket = r.ReadInt64();
            return ret;
        }
    }
	
    public static class ChatRoomInfoSerializer	
    {
        public static void Serialize(SampleC2SProtocol.ChatRoomInfo x, NativeWriter w)
        {
            if(x == null)
            {
                w.Write(false);
                return;
            }
            w.Write(true);
            w.Write(x.RoomId);
            w.WriteUnicode(x.RoomName);
        }
        
        public static SampleC2SProtocol.ChatRoomInfo Deserialize(NativeReader r)
        {
            {
                bool isNotNull = r.ReadBoolean();
                if(!isNotNull)
                    return null;
            }
            var ret = new SampleC2SProtocol.ChatRoomInfo();
            ret.RoomId = r.ReadUInt32();
            ret.RoomName = r.ReadUnicode();
            return ret;
        }
    }
}


