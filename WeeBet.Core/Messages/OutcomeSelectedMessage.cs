using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeeBet.Core.Messages
{
    public class OutcomeSelectedMessage : MvxMessage
    {
        public string OutcomeType { get; private set; }
        public OutcomeSelectedMessage(object sender, string outcomeType) : base(sender)
        {
            OutcomeType = outcomeType;
        }
    }
}
