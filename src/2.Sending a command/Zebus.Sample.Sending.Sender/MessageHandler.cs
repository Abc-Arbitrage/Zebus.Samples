using Abc.Zebus;
using log4net;
using Zebus.Sample.Common.Messages.Events;

namespace Zebus.Sample.Sending.Sender
{
    public class MessageHandler : IMessageHandler<NewThingsHaveBeenDone>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(MessageHandler));

        public void Handle(NewThingsHaveBeenDone message)
        {
            _log.InfoFormat("There is currently {0} things done ({1} just added)", message.TotalThingsDoneCount, message.NewThingsDoneCount);
        }
    }
}