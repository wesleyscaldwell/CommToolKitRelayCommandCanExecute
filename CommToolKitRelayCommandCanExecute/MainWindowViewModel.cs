using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CommToolKitRelayCommandCanExecute;

internal partial class MainWindowViewModel : INotifyPropertyChanged
{
    public string TestStatus 
    { 
        get => testStatus; 
        set 
        { 
            testStatus = value;
            OnPropertyChanged("TestStatus");
        }
    }

    [RelayCommand]
    async Task Button1()
    {
        var button2CanExecute = Button2Command.CanExecute(null).ToString(); ;
        ButtonTwoEnabled = false;
        TestStatus = $@"Button 1 Clicked - Button 2 Should be disabled - but isn't: Previous State: {button2CanExecute}";
    }

    [RelayCommand(CanExecute = "ButtonTwoEnabled")]
    async Task Button2()
    {
        ButtonTwoEnabled = false;
        TestStatus = "Button 2 Clicked - Button 2 Should be disabled - AND IS";
    }
    private bool buttonTwoEnabled = true;
    private string testStatus;

    public bool ButtonTwoEnabled
    {
        get => buttonTwoEnabled;
        set
        {
            buttonTwoEnabled = value;
            OnPropertyChanged("ButtonTwoEnabled");
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {

        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
