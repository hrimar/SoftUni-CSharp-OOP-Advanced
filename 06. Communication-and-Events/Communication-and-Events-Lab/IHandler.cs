using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectCommunicationAndEventsLab
{
   public interface IHandler
    {
        void Handle(LogType type, string message);

        void SetSuccessor(IHandler handler);

    }
}
