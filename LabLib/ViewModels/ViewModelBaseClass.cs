using LabLib.Services;
using System.ComponentModel;

namespace LabLib.ViewModels
{
    //Notifier class to notify any changes happening in the derived classes
    public class ViewModelBaseClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private IMessageBus _messageBus;
        public IMessageBus MessageBus
        {
            get { return _messageBus; }
            set
            {
                if(_messageBus!=null)
                {
                    UnSubcscribe();
                }
                _messageBus = value;
                Subscribe();
                OnPropertyChanged("MessageBus");
            }
        }

        
        protected void PublishMessage<TMessage>(TMessage message)
        {
            if (_messageBus != null)
            {
                _messageBus.Publish<TMessage>(message);
            }
        }

        public virtual void Subscribe() { }
        public virtual void UnSubcscribe() { }        
    }
}
