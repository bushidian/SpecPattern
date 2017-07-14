using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecPattern.Models
{
    public class ChatMessageRequest
    {
        public string Channel { get; set; }

        public string Content { get; set; }
    }
}
