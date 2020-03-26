using System.Threading.Tasks;

namespace SyncSoft.Olliix.Components
{
    public interface IPlatformService
    {
        Task Print(string purpose, string id);
    }
}
