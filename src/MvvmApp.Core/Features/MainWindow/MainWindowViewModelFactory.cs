using MvvmApp.Core.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmApp.Core.Features.MainWindow;
public class MainWindowViewModelFactory : PageViewModelFactoryBase<MainWindowViewModel>
{
    public override MainWindowViewModel Invoke()
    {
        return new MainWindowViewModel();
    }
}
