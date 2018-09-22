﻿using System;

namespace OChat.Core.ClientSide.Models
{
    public class ChatMessage
    {
        public string Username
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public DateTime Timestamp
        {
            get;
            set;
        }
    }
}
