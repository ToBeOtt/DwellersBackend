using Dwellers.Common.Data.Models.Household;

namespace Dwellers.Common.Data.Models.Notes
{
    public class NoteSubscriber
    {
        public Guid Id { get; set; }
        
        public HouseEntity House { get; set; }
        public Guid HouseId { get; set; }

        public NoteEntity Note { get; set; }
        public Guid NoteId { get; set; }

        public NoteSubscriber() { }

        public NoteSubscriber(HouseEntity house, NoteEntity note)
        {
            Id = Guid.NewGuid();
            House = house;
            Note = note;
        }
    }
}
