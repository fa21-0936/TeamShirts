using System.Net.Http.Json;
using TeamShirts.Models;

namespace TeamShirts.Services
{
    public class CamisetaService : ICamisetaService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CamisetaService> _logger;
        private readonly IConfiguration _configuration;


        public CamisetaService(
            HttpClient httpClient,
            ILogger<CamisetaService> logger,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
            _configuration = configuration;
        }


        public async Task<List<Camiseta>> GetCamisetas()
        {
            try
            {
                _logger.LogInformation("Consultando camisetas desde API");


                string? apiUrl = _configuration["ApiUrl"];


                var resultado = await _httpClient
                    .GetFromJsonAsync<List<Camiseta>>(
                        $"{apiUrl}api/Camisetas");


                return resultado ?? new List<Camiseta>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener camisetas");

                return new List<Camiseta>();
            }
        }
    }
}