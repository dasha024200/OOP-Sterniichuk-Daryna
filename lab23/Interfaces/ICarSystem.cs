namespace lab23.Interfaces
{
    public interface ICarSystem
    {
        void StartEngine();
        void StopEngine();
        void SetRadioStation(double freq);
        void TurnOnRadio();
        void TurnOffRadio();
        void NavigateTo(string destination);
    }
}
