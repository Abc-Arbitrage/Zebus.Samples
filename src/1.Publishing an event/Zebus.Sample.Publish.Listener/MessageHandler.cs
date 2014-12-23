using Abc.Zebus;
using log4net;
using Zebus.Sample.Common.Messages.Events;

namespace Zebus.Samples.Publish.Listener
{
    public class MessageHandler : IMessageHandler<SomethingHappened>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(MessageHandler));

        public void Handle(SomethingHappened message)
        {
            _log.Info("SomethingHappened event received and handled by the custom message handler");
        }
    }
}