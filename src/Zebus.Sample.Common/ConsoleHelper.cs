using System;
using System.Runtime.InteropServices;

namespace Zebus.Sample.Common
{
    public static class ConsoleHelper
    {
        [DllImport("Kernel32")]
        static extern bool SetConsoleCtrlHandler(HandlerRoutine handler, bool add);

        // A delegate type to be used as the handler routine 
        // for SetConsoleCtrlHandler.
        delegate bool HandlerRoutine(CtrlTypes ctrlType);

        // An enumerated type for the control messages
        // sent to the handler routine.
        enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }
        
        private class CallBackContext
        {
            private readonly Action _handler;

            public CallBackContext(Action handler)
            {
                _handler = handler;
            }

            public bool HandlerRoutine(CtrlTypes ctrlType)
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