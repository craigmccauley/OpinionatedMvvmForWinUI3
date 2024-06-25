using MvvmApp.Core.Infrastructure.Common;
using System;
using System.Threading.Tasks;

namespace MvvmApp.Core.Infrastructure.Application
{
    public interface IHooks
    {
        void ActivateMainWindow();
        IPageViewModel GetPageViewModel(Page page);
        void Initialize(IMainWindow mainWindow, IPageViewModelService pageViewModelService);
        Task RunOnUIThreadAsync(Action action);
    }
    public class Hooks : IHooks
    {
        private IMainWindow mainWindow;
        private IPageViewModelService pageViewModelService;
        private bool isInitialized;

        public void Initialize(IMainWindow mainWindow, IPageViewModelService pageViewModelService)
        {
            this.mainWindow ??= mainWindow;
            this.pageViewModelService ??= pageViewModelService;
            isInitialized = true;
        }
        public async Task RunOnUIThreadAsync(Action action)
        {
            if (!isInitialized) throw new Exception("Dispatcher not initialized");
            await mainWindow.DispatcherQueueEnqueueAsync(action);
        }

        public IPageViewModel GetPageViewModel(Page page)
        {
            if (!isInitialized) throw new Exception("Dispatcher not initialized");
            return pageViewModelService.GetPageViewModel(page);
        }

        public void ActivateMainWindow()
        {
            if (!isInitialized) throw new Exception("Dispatcher not initialized");
            mainWindow.Activate();
        }
    }
}
