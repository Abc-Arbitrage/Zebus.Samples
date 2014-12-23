using System.Threading;
using Abc.Zebus.Core;
using StructureMap;
using Zebus.Sample.Common;

namespace Zebus.Sample.Sending.Listener
{
    public class Receiver : SampleBase
    {
        private IContainer _container;

        protected override void Setup()
        {
            _container = new Container();
            _container.Configure(x => x.ForSingletonOf<ThingsDoneCounter>());
        }

        protected override void Run(CancellationToken cancellationToken)
        {
            var busFactory = new BusFactory(_container).WithScan()
                                                       .WithConfiguration("tcp://localhost:129", "Demo")
                                                       .WithPeerId("Receiver.*");

            using (busFactory.CreateAndStartBus())
            {
                cancellationToken.WaitHandle.WaitOne();
            }
        }
    }
}