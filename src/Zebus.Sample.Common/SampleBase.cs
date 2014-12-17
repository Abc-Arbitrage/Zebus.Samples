using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace Zebus.Samples.Common
{
    public abstract class SampleBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(SampleBase));
        private static readonly ManualResetEvent _applicationShutdownComplete = new ManualResetEvent(false);

        public void Start()
        {
            SetupLogging();
            CheckIfADirectoryIsStarted();

            var cancellationTokenSource = new CancellationTokenSource();

            _log.InfoFormat("Sample `{0}` starting", GetType().FullName);

            ConsoleHelper.OnExit(() =>
            {
                _log.Info("Shutdown requested by user");
                cancellationTokenSource.Cancel();

                _applicationShutdownComplete.WaitOne();
            });

            _log.Info("Calling setup");
            Setup();
            _log.Info("Finished setup");

            _log.Info("Calling main method");
            try
            {
                var mainTask = Task.Factory.StartNew(() => Run(cancellationTokenSource.Token), cancellationTokenSource.Token);
                mainTask.Wait();
            }
            catch (Exception ex)
            {
                _log.Error("Something went wrong !", ex);
            }

            _log.Info("Calling teardown");
            Teardown();
            _log.Info("Finished teardown");
            
            _log.InfoFormat("Sample `{0}` exit", GetType().FullName);
            _applicationShutdownComplete.Set();
        }

        private void CheckIfADirectoryIsStarted()
        {
            if(!Process.GetProcessesByName("Abc.Zebus.Directory").Any())
                _log.Warn("It seems that there is no directory running on the local machine. You should start the standalone directory in order to run the sample.");
        }

        protected virtual void Setup() { }

        protected abstract void Run(CancellationToken cancellationToken);

        protected virtual void Teardown() { }

        private static void SetupLogging()
        {
            var consoleAppender = new ConsoleAppender
            {
                Layout = new PatternLayout("%date{HH:mm:ss.fff} - %-5level - %logger || %message%newline"),
                Threshold = Level.Info
            };
            BasicConfigurator.Configure(consoleAppender);
        }
    }
}