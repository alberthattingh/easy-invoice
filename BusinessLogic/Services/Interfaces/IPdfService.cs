using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IPdfService
    {
        string GeneratePdf(string html);
    }
}