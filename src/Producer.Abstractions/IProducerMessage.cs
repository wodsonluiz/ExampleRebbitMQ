using System.Threading.Tasks;

namespace Producer.Abstractions
{
    public interface IProducerMessage
    {
        Task<bool> Send(string message);
    }
}
