public class EventService
{
    private readonly IEventRepository _eventRepository;
    private readonly ICalendarService _calendarService;

    public EventService(IEventRepository eventRepository, ICalendarService calendarService)
    {
        _eventRepository = eventRepository;
        _calendarService = calendarService;
    }

    public void CreateEvent(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Event name is required");

        _eventRepository.AddEvent(name);
        _calendarService.AddToCalendar(name);
    }

    public string? GetEvent(int id)
    {
        return _eventRepository.GetEvent(id);
    }
}