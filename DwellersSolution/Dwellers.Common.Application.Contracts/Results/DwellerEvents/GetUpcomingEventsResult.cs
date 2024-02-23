namespace Dwellers.Common.Application.Contracts.Results.DwellerEvents
{
    public class EventsDto(Guid id, string eventTitle, string eventText, string eventDate)
    {
        public string Id { get; set; } = id.ToString();
        public string EventTitle { get; set; } = eventTitle;
        public string EventText { get; set; } = eventText;
        public string EventDate { get; set; } = eventDate;
    }
    public record GetUpcomingEventsResult (
        ICollection<EventsDto> ListOfEvents
        );
}
