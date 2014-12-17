using System;
using System.Runtime.InteropServices;

namespace Zebus.Samples.Common
{
    public class ConsoleHelper
    {
        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);

        // A delegate type to be used as the handler routine 
        // for SetConsoleCtrlHandler.
        public delegate bool HandlerRoutine(CtrlTypes CtrlType);

        // An enumerated type for the control messages
        // sent to the handler routine.
        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }
        
        public class CallBackContext
        {
            private readonly Action _handler;

            public CallBackContext(Action handler)
            {
                _handler = handler;
            }

            public bool HandlerRoutine(CtrlTypes CtrlType)
            {
                _handler();
                return true;
            }
        }

        public static void OnExit(Action handler)
        {
            var context = new CallBackContext(handler);
            SetConsoleCtrlHandler(context.HandlerRoutine, true);    
        } 
    }
}