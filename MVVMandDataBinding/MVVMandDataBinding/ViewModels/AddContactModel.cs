using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace MVVMandDataBinding.ViewModels
{
    public class AddContactModel : INotifyPropertyChanged
    {
        //private fields
        private string _name = "NASIR";
        private string _website = "https://google.com/";
        private bool _bestFriend;
        private bool _isBusy;

        public event PropertyChangedEventHandler PropertyChanged;
        public Command LaunchWebsiteCommand { get; }
        public Command SaveContactCommand { get; }

        //the class constructor
        public AddContactModel()
        {
            LaunchWebsiteCommand = new Command(LaunchWebsite, () => !IsBusy);
            SaveContactCommand = new Command(async () => await SaveContact(), () => !IsBusy);
        }


        //class public properties
        public bool BestFriend
        {
            get { return _bestFriend; }
            set
            {
                _bestFriend = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;

                IsBusy = (Name == "Elmo") ? true : false;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public string Website
        {
            get { return _website; }
            set
            {
                _website = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
                LaunchWebsiteCommand.ChangeCanExecute();
                SaveContactCommand.ChangeCanExecute();
            }
        }
        private void OnPropertyChanged([CallerMemberName]string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }



        //class public methods
        public string DisplayMessage
        {
            get
            {
                return $"Your new friend is names {_name} z" +
                $"{(_bestFriend ? "is" : "is not")} your best friend.";
            }
        }


        public void LaunchWebsite()
        {
            try
            {
                Device.OpenUri(new Uri(_website));
            }
            catch (Exception ex)
            {
            Application.Current.MainPage.DisplayAlert("Error",ex.Message, "Ok");

            }

        }

        public async Task SaveContact()
        {
            IsBusy = true;
            await Task.Delay(4000);

            IsBusy = false;

            await Application.Current.MainPage.DisplayAlert("Save", "Your Contact is Saved", "Ok");
        }

    }
}
