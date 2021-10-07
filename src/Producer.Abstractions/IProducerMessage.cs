using System.Threading.Tasks;

namespace Producer.Abstractions
{
    public interface IProducerMessage
    {
        void Send(string message);
    }
}
