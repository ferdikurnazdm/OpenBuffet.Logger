using System.Timers;
using OpenBuffet.Logger.Core.Extentions;
using OpenBuffet.Logger.Core.Interfaces;
using OpenBuffet.Logger.Core.Managers;
using OpenBuffet.Logger.Core.Types;
using Microsoft.Extensions.DependencyInjection;

internal class Program {
    private static void Main(string[] args) {
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddOpenBuffetConsoleLogger()
            .AddOpenBuffetTextLogger(configuration => {
                configuration.Path = AppDomain.CurrentDomain.BaseDirectory;
            })
            .AddOpenBuffetJsonlLogger(configuration => {
                configuration.Path = AppDomain.CurrentDomain.BaseDirectory;
            })
            .AddOpenBuffetLoggerManager()
            .AddSingleton<Chronometer>()
            .BuildServiceProvider();
        var chronometer = serviceProvider.GetService<Chronometer>();
        while (true) { Thread.Sleep(1000); }
    }
}





internal class Chronometer {
    private readonly LoggerManager _loggerManager;
    private readonly System.Timers.Timer _timer;


    public Chronometer(LoggerManager loggerManager) {
        _loggerManager = loggerManager;
        _timer = new System.Timers.Timer();
        _timer.AutoReset = true;
        _timer.Interval = 1000;
        _timer.Elapsed += _timer_Elapsed;
        _timer.Start();
    }

    private void _timer_Elapsed(object sender, ElapsedEventArgs e) {
        _timer.Stop();
        ShowTimeOnConsole("Hello from chronometer");
        _timer.Start();
    }

    public void ShowTimeOnConsole(string message) {
        Exception exception = null;
        //_loggerManager.TryCleanLogs(out exception);
        _loggerManager.TryLogging(LogType.ERROR, message, out exception);
    }





}
