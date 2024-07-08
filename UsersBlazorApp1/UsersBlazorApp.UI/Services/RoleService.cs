using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.UI.Services
{
    public class RoleService : IClientService<AspNetRoles>
    {
        private readonly HttpClient _httpClient;

        public RoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AspNetRoles>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<AspNetRoles>>("api/AspNetRoles");
            }
            catch (HttpRequestException ex)
            {
                // Manejar la excepción, por ejemplo, loguearla o lanzar un mensaje de error
                Console.WriteLine($"Error al obtener los roles: {ex.Message}");
                throw;
            }
        }

        public async Task<AspNetRoles> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<AspNetRoles>($"api/AspNetRoles/{id}");
        }

        public async Task<AspNetRoles> AddAsync(AspNetRoles entity)
        {
            var response = await _httpClient.PostAsJsonAsync("api/AspNetRoles", entity);
            return await response.Content.ReadFromJsonAsync<AspNetRoles>();
        }

        public async Task<bool> UpdateAsync(AspNetRoles entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/AspNetRoles/{entity.Id}", entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/AspNetRoles/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
