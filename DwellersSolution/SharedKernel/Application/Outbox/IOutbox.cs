using System.Threading.Tasks;

namespace SharedKernel.Application.Outbox
{
    public interface IOutbox
    {
        void Add(OutboxMessage message);

        Task Save();
    }
}