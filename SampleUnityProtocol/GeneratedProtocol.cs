﻿using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MOUSE.Core;
using UnityClient;

namespace Protocol.Generated
{
	[NetContract]
	public interface IChatLogin
	{
		IEnumerable Login ( String name,  OperationReply< LoginResult > reply);
	}
	[NetContract]
	public interface IChatService
	{
		IEnumerable GetRooms (  OperationReply< List<ChatRoomInfo> > reply);
		IEnumerable JoinOrCreateRoom ( String roomName,  OperationReply< CreateRoomResponse > reply);
		IEnumerable JoinRoom ( UInt32 roomId,  OperationReply< Int64 > reply);
	}
	[NetContract]
	public interface IChatRoomService
	{
		IEnumerable Join ( Int64 ticket,  OperationReply< List<String> > reply);
		void Say ( String message );
	}
	[NetContract]
	public interface IChatRoomServiceCallback
	{
		void OnRoomMessage ( UInt32 roomId, String message );
	}
	[NetProxy(ContractTypeId = 1279047273, ContractType = typeof(IChatLogin))]
	public sealed class IChatLoginProxy : NodeServiceProxy, IChatLogin
	{
		public IEnumerable Login ( String name,  OperationReply< LoginResult > replyChannel)
		{
			//var request = MessageFactory.New< IChatLoginLoginRequest >();
			var request = new IChatLoginLoginRequest();
			request.name=name;
			var msgReply = new OperationReply<Message>();
			foreach(object obj in ExecuteServiceOperation(request, msgReply))
				 yield return obj;
			if(msgReply.IsValid)
				replyChannel.SetReply( ((IChatLoginLoginReply)msgReply.Reply).RetVal, null);
			else
				replyChannel.SetReply(default(LoginResult), msgReply.Error);
			//MessageFactory.Free(reply);
			//MessageFactory.Free(request);
		}
		[NetOperationDispatcher(RequestMessage = typeof(IChatLoginLoginRequest), ReplyMessage = typeof(IChatLoginLoginReply))]
		public static void Login(IMessageFactory msgFactory, object target, Message input)
		{
			var msg = (IChatLoginLoginRequest)input;
			throw new NotSupportedException();
		}
	}
	[NetProxy(ContractTypeId = 4131147598, ContractType = typeof(IChatService))]
	public sealed class IChatServiceProxy : NodeServiceProxy, IChatService
	{
		public IEnumerable GetRooms (  OperationReply< List<ChatRoomInfo> > replyChannel)
		{
			//var request = MessageFactory.New< IChatServiceGetRoomsRequest >();
			var request = new IChatServiceGetRoomsRequest();
			var msgReply = new OperationReply<Message>();
			foreach(object obj in ExecuteServiceOperation(request, msgReply))
				 yield return obj;
			if(msgReply.IsValid)
				replyChannel.SetReply( ((IChatServiceGetRoomsReply)msgReply.Reply).RetVal, null);
			else
				replyChannel.SetReply(default(List<ChatRoomInfo>), msgReply.Error);
			//MessageFactory.Free(reply);
			//MessageFactory.Free(request);
		}
		[NetOperationDispatcher(RequestMessage = typeof(IChatServiceGetRoomsRequest), ReplyMessage = typeof(IChatServiceGetRoomsReply))]
		public static void GetRooms(IMessageFactory msgFactory, object target, Message input)
		{
			var msg = (IChatServiceGetRoomsRequest)input;
			throw new NotSupportedException();
		}
		public IEnumerable JoinOrCreateRoom ( String roomName,  OperationReply< CreateRoomResponse > replyChannel)
		{
			//var request = MessageFactory.New< IChatServiceJoinOrCreateRoomRequest >();
			var request = new IChatServiceJoinOrCreateRoomRequest();
			request.roomName=roomName;
			var msgReply = new OperationReply<Message>();
			foreach(object obj in ExecuteServiceOperation(request, msgReply))
				 yield return obj;
			if(msgReply.IsValid)
				replyChannel.SetReply( ((IChatServiceJoinOrCreateRoomReply)msgReply.Reply).RetVal, null);
			else
				replyChannel.SetReply(default(CreateRoomResponse), msgReply.Error);
			//MessageFactory.Free(reply);
			//MessageFactory.Free(request);
		}
		[NetOperationDispatcher(RequestMessage = typeof(IChatServiceJoinOrCreateRoomRequest), ReplyMessage = typeof(IChatServiceJoinOrCreateRoomReply))]
		public static void JoinOrCreateRoom(IMessageFactory msgFactory, object target, Message input)
		{
			var msg = (IChatServiceJoinOrCreateRoomRequest)input;
			throw new NotSupportedException();
		}
		public IEnumerable JoinRoom ( UInt32 roomId,  OperationReply< Int64 > replyChannel)
		{
			//var request = MessageFactory.New< IChatServiceJoinRoomRequest >();
			var request = new IChatServiceJoinRoomRequest();
			request.roomId=roomId;
			var msgReply = new OperationReply<Message>();
			foreach(object obj in ExecuteServiceOperation(request, msgReply))
				 yield return obj;
			if(msgReply.IsValid)
				replyChannel.SetReply( ((IChatServiceJoinRoomReply)msgReply.Reply).RetVal, null);
			else
				replyChannel.SetReply(default(Int64), msgReply.Error);
			//MessageFactory.Free(reply);
			//MessageFactory.Free(request);
		}
		[NetOperationDispatcher(RequestMessage = typeof(IChatServiceJoinRoomRequest), ReplyMessage = typeof(IChatServiceJoinRoomReply))]
		public static void JoinRoom(IMessageFactory msgFactory, object target, Message input)
		{
			var msg = (IChatServiceJoinRoomRequest)input;
			throw new NotSupportedException();
		}
	}
	[NetProxy(ContractTypeId = 2616972471, ContractType = typeof(IChatRoomService))]
	public sealed class IChatRoomServiceProxy : NodeServiceProxy, IChatRoomService
	{
		public IEnumerable Join ( Int64 ticket,  OperationReply< List<String> > replyChannel)
		{
			//var request = MessageFactory.New< IChatRoomServiceJoinRequest >();
			var request = new IChatRoomServiceJoinRequest();
			request.ticket=ticket;
			var msgReply = new OperationReply<Message>();
			foreach(object obj in ExecuteServiceOperation(request, msgReply))
				 yield return obj;
			if(msgReply.IsValid)
				replyChannel.SetReply( ((IChatRoomServiceJoinReply)msgReply.Reply).RetVal, null);
			else
				replyChannel.SetReply(default(List<String>), msgReply.Error);
			//MessageFactory.Free(reply);
			//MessageFactory.Free(request);
		}
		[NetOperationDispatcher(RequestMessage = typeof(IChatRoomServiceJoinRequest), ReplyMessage = typeof(IChatRoomServiceJoinReply))]
		public static void Join(IMessageFactory msgFactory, object target, Message input)
		{
			var msg = (IChatRoomServiceJoinRequest)input;
			throw new NotSupportedException();
		}
		public void Say ( String message )
		{
			//var request = MessageFactory.New< IChatRoomServiceSayRequest >();
			var request = new IChatRoomServiceSayRequest();
			request.message=message;
			ExecuteOneWayServiceOperation(request);
			//MessageFactory.Free(request);
		}
		[NetOperationDispatcher(RequestMessage = typeof(IChatRoomServiceSayRequest), ReplyMessage = null)]
		public static void Say(IMessageFactory msgFactory, object target, Message input)
		{
			var msg = (IChatRoomServiceSayRequest)input;
			((IChatRoomService)target).Say(msg.message);
		}
	}
	[NetProxy(ContractTypeId = 3421052361, ContractType = typeof(IChatRoomServiceCallback))]
	public sealed class IChatRoomServiceCallbackProxy : NodeServiceProxy, IChatRoomServiceCallback
	{
		public void OnRoomMessage ( UInt32 roomId, String message )
		{
			//var request = MessageFactory.New< IChatRoomServiceCallbackOnRoomMessageRequest >();
			var request = new IChatRoomServiceCallbackOnRoomMessageRequest();
			request.roomId=roomId;
			request.message=message;
			ExecuteOneWayServiceOperation(request);
			//MessageFactory.Free(request);
		}
		[NetOperationDispatcher(RequestMessage = typeof(IChatRoomServiceCallbackOnRoomMessageRequest), ReplyMessage = null)]
		public static void OnRoomMessage(IMessageFactory msgFactory, object target, Message input)
		{
			var msg = (IChatRoomServiceCallbackOnRoomMessageRequest)input;
			((IChatRoomServiceCallback)target).OnRoomMessage(msg.roomId, msg.message);
		}
	}
    public sealed class IChatLoginLoginRequest : Message
    {
        public String name;

        public override uint Id
        {
            get { return 2019756658; }
        }

        public override void Serialize(BinaryWriter w)
        {
            base.Serialize(w);
            w.Write(name);
        }

        public override void Deserialize(BinaryReader r)
        {
            base.Deserialize(r);
            name = r.ReadString();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    public sealed class IChatLoginLoginReply : Message
    {
        public LoginResult RetVal;

        public override uint Id
        {
            get { return 1128145376; }
        }

        public override void Serialize(BinaryWriter w)
        {
            base.Serialize(w);
            w.Write((Byte)RetVal);
        }

        public override void Deserialize(BinaryReader r)
        {
            base.Deserialize(r);
            RetVal = (LoginResult)r.ReadByte();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    public sealed class IChatServiceGetRoomsRequest : Message
    {

        public override uint Id
        {
            get { return 1938706274; }
        }

        public override void Serialize(BinaryWriter w)
        {
            base.Serialize(w);
        }

        public override void Deserialize(BinaryReader r)
        {
            base.Deserialize(r);
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    public sealed class IChatServiceGetRoomsReply : Message
    {
        public List<ChatRoomInfo> RetVal;

        public override uint Id
        {
            get { return 1966421887; }
        }

        public override void Serialize(BinaryWriter w)
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

        public override void Deserialize(BinaryReader r)
        {
            base.Deserialize(r);
            {
                bool isNotNull = r.ReadBoolean();
                if(!isNotNull)
                    RetVal = null;
                else
                {
                    int lenght = r.ReadInt32();
                    var list = new List<ChatRoomInfo>(lenght);
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
    public sealed class IChatServiceJoinOrCreateRoomRequest : Message
    {
        public String roomName;

        public override uint Id
        {
            get { return 956401361; }
        }

        public override void Serialize(BinaryWriter w)
        {
            base.Serialize(w);
            w.Write(roomName);
        }

        public override void Deserialize(BinaryReader r)
        {
            base.Deserialize(r);
            roomName = r.ReadString();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    public sealed class IChatServiceJoinOrCreateRoomReply : Message
    {
        public CreateRoomResponse RetVal;

        public override uint Id
        {
            get { return 1860964580; }
        }

        public override void Serialize(BinaryWriter w)
        {
            base.Serialize(w);
            CreateRoomResponseSerializer.Serialize(RetVal, w);
        }

        public override void Deserialize(BinaryReader r)
        {
            base.Deserialize(r);
            RetVal = CreateRoomResponseSerializer.Deserialize(r);
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    public sealed class IChatServiceJoinRoomRequest : Message
    {
        public UInt32 roomId;

        public override uint Id
        {
            get { return 4139561538; }
        }

        public override void Serialize(BinaryWriter w)
        {
            base.Serialize(w);
            w.Write(roomId);
        }

        public override void Deserialize(BinaryReader r)
        {
            base.Deserialize(r);
            roomId = r.ReadUInt32();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    public sealed class IChatServiceJoinRoomReply : Message
    {
        public Int64 RetVal;

        public override uint Id
        {
            get { return 693987992; }
        }

        public override void Serialize(BinaryWriter w)
        {
            base.Serialize(w);
            w.Write(RetVal);
        }

        public override void Deserialize(BinaryReader r)
        {
            base.Deserialize(r);
            RetVal = r.ReadInt64();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    public sealed class IChatRoomServiceJoinRequest : Message
    {
        public Int64 ticket;

        public override uint Id
        {
            get { return 3112933142; }
        }

        public override void Serialize(BinaryWriter w)
        {
            base.Serialize(w);
            w.Write(ticket);
        }

        public override void Deserialize(BinaryReader r)
        {
            base.Deserialize(r);
            ticket = r.ReadInt64();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    public sealed class IChatRoomServiceJoinReply : Message
    {
        public List<String> RetVal;

        public override uint Id
        {
            get { return 4292680201; }
        }

        public override void Serialize(BinaryWriter w)
        {
            base.Serialize(w);
            if(RetVal != null)
            {
                w.Write(true);
                w.Write((int)RetVal.Count);
                foreach(var element in RetVal)
                    w.Write(element);
            }
            else
                w.Write(false);
        }

        public override void Deserialize(BinaryReader r)
        {
            base.Deserialize(r);
            {
                bool isNotNull = r.ReadBoolean();
                if(!isNotNull)
                    RetVal = null;
                else
                {
                    int lenght = r.ReadInt32();
                    var list = new List<String>(lenght);
                    for(int i = 0; i < lenght; i++)
                    {
                        var x = r.ReadString();
                        list.Add(x);
                    }
                    RetVal = list;
                }
            }
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    public sealed class IChatRoomServiceSayRequest : Message
    {
        public String message;

        public override uint Id
        {
            get { return 999376688; }
        }

        public override void Serialize(BinaryWriter w)
        {
            base.Serialize(w);
            w.Write(message);
        }

        public override void Deserialize(BinaryReader r)
        {
            base.Deserialize(r);
            message = r.ReadString();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
    public sealed class IChatRoomServiceCallbackOnRoomMessageRequest : Message
    {
        public UInt32 roomId;
        public String message;

        public override uint Id
        {
            get { return 673625236; }
        }

        public override void Serialize(BinaryWriter w)
        {
            base.Serialize(w);
            w.Write(roomId);
            w.Write(message);
        }

        public override void Deserialize(BinaryReader r)
        {
            base.Deserialize(r);
            roomId = r.ReadUInt32();
            message = r.ReadString();
        }

        public override MessagePriority Priority { get { return MessagePriority.Medium; } }
        public override MessageReliability Reliability { get { return MessageReliability.ReliableOrdered; } }
    }
	
	public enum LoginResult : byte
	{
		Ok = 0,
		NameInUse = 1,
		AlreadyRegistered = 2,
	}
	
	public enum JoinRoomInvalidRetCode : int
	{
		RoomNotFound = 0,
		ClientNotAwaited = 1,
	}
	
	public class CreateRoomResponse
	{
		public UInt32 RoomId;
		public Int64 Ticket;
	}
	
	public class ChatRoomInfo
	{
		public UInt32 Id;
		public String Name;
	}
	
    public static class CreateRoomResponseSerializer	
    {
        public static void Serialize(CreateRoomResponse x, BinaryWriter w)
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
        
        public static CreateRoomResponse Deserialize(BinaryReader r)
        {
            {
                bool isNotNull = r.ReadBoolean();
                if(!isNotNull)
                    return null;
            }
            var ret = new CreateRoomResponse();
            ret.RoomId = r.ReadUInt32();
            ret.Ticket = r.ReadInt64();
            return ret;
        }
    }
	
    public static class ChatRoomInfoSerializer	
    {
        public static void Serialize(ChatRoomInfo x, BinaryWriter w)
        {
            if(x == null)
            {
                w.Write(false);
                return;
            }
            w.Write(true);
            w.Write(x.Id);
            w.Write(x.Name);
        }
        
        public static ChatRoomInfo Deserialize(BinaryReader r)
        {
            {
                bool isNotNull = r.ReadBoolean();
                if(!isNotNull)
                    return null;
            }
            var ret = new ChatRoomInfo();
            ret.Id = r.ReadUInt32();
            ret.Name = r.ReadString();
            return ret;
        }
    }
}


