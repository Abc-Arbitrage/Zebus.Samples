namespace Zebus.Sample.Sending.Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = new Receiver();
            receiver.Start();
        }
    }
}