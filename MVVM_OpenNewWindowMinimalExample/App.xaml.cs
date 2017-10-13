using System.Windows;
using MVVM_OpenNewWindowMinimalExample.Views;
using MVVM_OpenNewWindowMinimalExample.ViewModels;

namespace MVVM_OpenNewWindowMinimalExample {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            var modelView = new MainWindowView {
                DataContext = new MainWindowViewModel()
            };
            modelView.Show();
        }
    } 
}
