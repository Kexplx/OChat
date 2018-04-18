using OChatNew.Core.Connection.Server.Communication;
using System;
using System.Linq;

namespace OChatNew.Core.Connection.Communication
{
    public class Message
    {
        public MessageType Type
        {
            get
            {
                return GetMessageType();
            }
        }

        public string Username
        {
            get;
            set;
        }

        public DateTime TimeStamp
        {
            get;
            set;
        }

        /// <summary>
        /// with prefix and content
        /// </summary>
        public string RawMessageContent
        {
            get;
            set;
        }

        public MessageType GetMessageType()
        {
            var prefix = RawMessageContent.Split(':').First();

            switch (prefix)
            {
                case "USERWENTOFFLINE":
                    return MessageType.USERWENTOFFLINE;

                case "USERWENTONLINE":
                    return MessageType.USERWENTONLINE;

                case "CONTENTMSG":
                    return MessageType.CONTENTMSG;

                case "ONLINEUSERS":
                    return MessageType.ONLINEUSERS;

                default:
                    return MessageType.ONLINEUSERS;
            }
        }
    }
}