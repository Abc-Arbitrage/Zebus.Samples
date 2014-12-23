namespace Zebus.Sample.Sending.Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var publisher = new Publisher();
            publisher.Start();
        }
    }
}