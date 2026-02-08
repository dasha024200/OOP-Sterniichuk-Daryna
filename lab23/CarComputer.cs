using lab23.Interfaces;

namespace lab23
{
    public class CarComputer
    {
        private readonly IEngineControl _engine;
        private readonly IRadioControl _radio;
        private readonly INavigation _navigation;

        public CarComputer(IEngineControl engine, IRadioControl radio, INavigation navigation)
        {
            _engine = engine;
            _radio = radio;
            _navigation = navigation;
        }
        public void StartCar() => _engine.Start();
        public void StopCar() => _engine.Stop();

        public void PlayRadio(double freq)
        {
            _radio.On();
            _radio.SetStation(freq);
        }

        public void StopRadio() => _radio.Off();

        public void GoTo(string destination) => _navigation.NavigateTo(destination);
    }
}
