using Moq;
using Xunit;

public class EventServiceTests
{
    private readonly Mock<IEventRepository> _eventRepoMock;
    private readonly Mock<ICalendarService> _calendarMock;
    private readonly EventService _service;

    public EventServiceTests()
    {
        _eventRepoMock = new Mock<IEventRepository>();
        _calendarMock = new Mock<ICalendarService>();
        _service = new EventService(_eventRepoMock.Object, _calendarMock.Object);
    }

    [Fact]
    public void CreateEvent_ValidName_CallsRepository()
    {
        _service.CreateEvent("Party");

        _eventRepoMock.Verify(r => r.AddEvent("Party"), Times.Once);
    }

    [Fact]
    public void CreateEvent_ValidName_CallsCalendar()
    {
        _service.CreateEvent("Party");

        _calendarMock.Verify(c => c.AddToCalendar("Party"), Times.Once);
    }

    [Fact]
    public void CreateEvent_EmptyName_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => _service.CreateEvent(""));
    }

    [Fact]
    public void GetEvent_ReturnsCorrectValue()
    {
        _eventRepoMock.Setup(r => r.GetEvent(1)).Returns("Meeting");

        var result = _service.GetEvent(1);

        Assert.Equal("Meeting", result);
    }

    [Fact]
    public void GetEvent_CallsRepository()
    {
        _service.GetEvent(2);

        _eventRepoMock.Verify(r => r.GetEvent(2), Times.Once);
    }

    [Fact]
    public void CreateEvent_VerifyBothDependenciesCalled()
    {
        _service.CreateEvent("Conference");

        _eventRepoMock.Verify(r => r.AddEvent("Conference"), Times.Once);
        _calendarMock.Verify(c => c.AddToCalendar("Conference"), Times.Once);
    }

    [Fact]
    public void GetEvent_Null_ReturnsNull()
    {
        _eventRepoMock.Setup(r => r.GetEvent(5)).Returns((string?)null);

        var result = _service.GetEvent(5);

        Assert.Null(result);
    }

    [Fact]
    public void CreateEvent_MultipleCalls_WorkCorrectly()
    {
        _service.CreateEvent("A");
        _service.CreateEvent("B");

        _eventRepoMock.Verify(r => r.AddEvent(It.IsAny<string>()), Times.Exactly(2));
    }
}