﻿using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.UI.Services
{
    public class ClaimService : IClientService<AspNetRoleClaims>
    {
        private readonly HttpClient _httpClient;

        public ClaimService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AspNetRoleClaims>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<AspNetRoleClaims>>("api/AspNetRoleClaims");
            }
            catch (HttpRequestException ex)
            {
                // Manejar la excepción, por ejemplo, loguearla o lanzar un mensaje de error
                Console.WriteLine($"Error al obtener las reclamaciones: {ex.Message}");
                throw;
            }
        }

        public async Task<AspNetRoleClaims> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<AspNetRoleClaims>($"api/AspNetRoleClaims/{id}");
        }

        public async Task<AspNetRoleClaims> AddAsync(AspNetRoleClaims entity)
        {
            var response = await _httpClient.PostAsJsonAsync("api/AspNetRoleClaims", entity);
            return await response.Content.ReadFromJsonAsync<AspNetRoleClaims>();
        }

        public async Task<bool> UpdateAsync(AspNetRoleClaims entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/AspNetRoleClaims/{entity.Id}", entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/AspNetRoleClaims/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
