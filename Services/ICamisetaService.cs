using TeamShirts.Models;

namespace TeamShirts.Services
{
    public interface ICamisetaService
    {
        Task<List<Camiseta>> GetCamisetas();
    }
}
