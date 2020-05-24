using System;
using System.Threading.Tasks;

namespace PowerPlantCodingChallenge.Controllers
{
    public interface ISimpleWebSocketHandler
    {
        Task SendMessage(string message);
    }
}
