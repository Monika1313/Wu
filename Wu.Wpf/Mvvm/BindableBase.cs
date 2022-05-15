using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wu.Wpf.Mvvm
{
    //
    // 摘要:
    //     Implementation of System.ComponentModel.INotifyPropertyChanged to simplify models.
    public abstract class BindableBase : INotifyPropertyChanged
    {
        //
        // 摘要:
        //     Occurs when a property value changes.
        public event PropertyChangedEventHandler? PropertyChanged;

        //
        // 摘要:
        //     Checks if a property already matches a desired value. Sets the property and notifies
        //     listeners only when necessary.
        //
        // 参数:
        //   storage:
        //     Reference to a property with both getter and setter.
        //
        //   value:
        //     Desired value for the property.
        //
        //   propertyName:
        //     Name of the property used to notify listeners. This value is optional and can
        //     be provided automatically when invoked from compilers that support CallerMemberName.
        //
        // 类型参数:
        //   T:
        //     Type of the property.
        //
        // 返回结果:
        //     True if the value was changed, false if the existing value matched the desired
        //     value.
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        //
        // 摘要:
        //     Checks if a property already matches a desired value. Sets the property and notifies
        //     listeners only when necessary.
        //
        // 参数:
        //   storage:
        //     Reference to a property with both getter and setter.
        //
        //   value:
        //     Desired value for the property.
        //
        //   propertyName:
        //     Name of the property used to notify listeners. This value is optional and can
        //     be provided automatically when invoked from compilers that support CallerMemberName.
        //
        //   onChanged:
        //     Action that is called after the property value has been changed.
        //
        // 类型参数:
        //   T:
        //     Type of the property.
        //
        // 返回结果:
        //     True if the value was changed, false if the existing value matched the desired
        //     value.
        protected virtual bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            onChanged?.Invoke();
            RaisePropertyChanged(propertyName);
            return true;
        }

        //
        // 摘要:
        //     Raises this object's PropertyChanged event.
        //
        // 参数:
        //   propertyName:
        //     Name of the property used to notify listeners. This value is optional and can
        //     be provided automatically when invoked from compilers that support System.Runtime.CompilerServices.CallerMemberNameAttribute.
        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        //
        // 摘要:
        //     Raises this object's PropertyChanged event.
        //
        // 参数:
        //   args:
        //     The PropertyChangedEventArgs
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            this.PropertyChanged?.Invoke(this, args);
        }
    }
}
