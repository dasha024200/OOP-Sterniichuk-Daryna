public interface IEventRepository
{
    void AddEvent(string name);
    string? GetEvent(int id);
}

public interface ICalendarService
{
    void AddToCalendar(string eventName);
}