using System.Windows;
using MVVM_OpenNewWindowMinimalExample.Views;
using MVVM_OpenNewWindowMinimalExample.ViewModels;
using System.Threading.Tasks;

namespace MVVM_OpenNewWindowMinimalExample {
    public partial class App : Application {

        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();
        MainWindowViewModel mainWindowViewModel;

        public App()
        {
            displayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindowView>();
            displayRootRegistry.RegisterWindowType<OtherWindowViewModel, ChildWindow>();
            displayRootRegistry.RegisterWindowType<DialogWindowViewModel, DialogWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            mainWindowViewModel = new MainWindowViewModel();

            await displayRootRegistry.ShowModalPresentation(mainWindowViewModel);

            Shutdown();
        }
    }
}
