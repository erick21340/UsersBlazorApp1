using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.UI.Services
{
    public class UsuarioService : IClientService<AspNetUsers>
    {
        private readonly HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AspNetUsers>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<AspNetUsers>>("api/AspNetUsers");
        }

        public async Task<AspNetUsers> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<AspNetUsers>($"api/AspNetUsers/{id}");
        }

        public async Task<AspNetUsers> AddAsync(AspNetUsers entity)
        {
            var response = await _httpClient.PostAsJsonAsync("api/AspNetUsers", entity);
            return await response.Content.ReadFromJsonAsync<AspNetUsers>();
        }

        public async Task<bool> UpdateAsync(AspNetUsers entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/AspNetUsers/{entity.Id}", entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/AspNetUsers/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
