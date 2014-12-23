using System.Threading;
using Abc.Zebus.Core;
using Zebus.Sample.Common;

namespace Zebus.Samples.Publish.Listener
{
    internal class Receiver : SampleBase
    {
        protected override void Run(CancellationToken cancellationToken)
        {
            var busFactory = new BusFactory().WithScan()
                                             .WithConfiguration("tcp://localhost:129", "Demo")
                                             .WithPeerId("Receiver.*");

            using (busFactory.CreateAndStartBus())
            {
                cancellationToken.WaitHandle.WaitOne();
            }
        }
    }
}