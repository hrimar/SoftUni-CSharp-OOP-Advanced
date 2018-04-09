using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectCommunicationAndEventsLab
{
    public abstract class Logger : IHandler
    {
        private IHandler successor;



        public abstract void Handle(LogType type, string message);

        public void SetSuccessor(IHandler seccessor)
        {
            this.successor = seccessor;
        }

        protected void PassToSuccessor(LogType type, string message)
        {
            if (this.successor != null)
            {
                this.successor.Handle(type, message);

            }
        }
    }
}
