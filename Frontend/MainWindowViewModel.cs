using Backend.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Frontend
{
    internal class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<MessageModel> Messages { get; set; }
        private MessageModel selectedmessage;

     public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MessageModel SelectedMessage
        {
            get { return selectedmessage; }
            set
            {
                if (value != null)
                {
                    selectedmessage = new MessageModel()
                    {
                        Name = value.Name,
                        Message = value.Message,
                    };
                    OnPropertyChanged();

                }
            }
        }
        public ICommand CreateMessageCommand { get; set; }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Messages = new RestCollection<MessageModel>("https://localhost:7166", "messages");
                CreateMessageCommand = new RelayCommand(() =>
                {
                    Messages.Add(new MessageModel() { Name = selectedmessage.Name, Message = selectedmessage.Message });
                });
            }
        }
    }
}
