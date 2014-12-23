using Zebus.Sample.Common;

namespace Zebus.Samples.Publish.Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleBase sender = new Publisher();
            sender.Start();
        }
    }
}
