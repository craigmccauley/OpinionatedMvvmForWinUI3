using MvvmApp.Core.Features.MainWindow;
using System;
using System.Threading.Tasks;

namespace MvvmApp.Core.Infrastructure.Application
{
    public interface IMainWindow
    {
        string Title { get; set; }
        MainWindowViewModel ViewModel { get; }
        void Activate();
        Task DispatcherQueueEnqueueAsync(Action action);
        event EventHandler MainWindowClosed;
    }
}