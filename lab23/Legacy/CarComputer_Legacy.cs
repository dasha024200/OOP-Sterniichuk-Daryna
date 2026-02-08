using lab23.Interfaces;

namespace lab23.Legacy
{
    public class CarComputer_Legacy : ICarSystem
    {
        private readonly EngineUnit _engine = new EngineUnit();
        private readonly RadioTuner _radio = new RadioTuner();
        private readonly GPSModule _gps = new GPSModule();

        public void StartEngine() => _engine.Start();
        public void StopEngine() => _engine.Stop();

        public void TurnOnRadio() => _radio.On();
        public void TurnOffRadio() => _radio.Off();
        public void SetRadioStation(double freq) => _radio.SetStation(freq);

        public void NavigateTo(string destination) => _gps.GoTo(destination);
    }
}
