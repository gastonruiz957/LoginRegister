using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace LoginRegister
{
    class ShowPasswordTriggerAction : TriggerAction<ImageButton>, INotifyPropertyChanged
    {
        
        public string ShowIcon { get; set; }
        public string HiddenIcon { get; set; }

        bool _hiddePassword = true;

        public bool HiddePasword
        {
            get
            {
                return _hiddePassword;
            }
            set
            {
                if(_hiddePassword != value)
                {
                    _hiddePassword = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HiddePasword)));
                }
            }
        }
        
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected override void Invoke(ImageButton sender)
        {
            sender.Source = HiddePasword ? ShowIcon : HiddenIcon;
            HiddePasword = !HiddePasword;
        }
    }
}
