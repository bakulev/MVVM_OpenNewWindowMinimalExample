using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace MVVM_OpenNewWindowMinimalExample.ViewModels {

    class BasicViewModel {

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null) {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}