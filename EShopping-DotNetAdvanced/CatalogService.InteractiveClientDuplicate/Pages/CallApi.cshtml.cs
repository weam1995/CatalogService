﻿using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatalogService.Interactive.Pages
{
    public class CallApiModel(IHttpClientFactory httpClientFactory) : PageModel
    {
        public string Json = string.Empty;

        public async Task OnGet()
        {
            var client = httpClientFactory.CreateClient("apiClient");
            var content = await client.GetStringAsync("https://localhost:7182/identity");

            var parsed = JsonDocument.Parse(content);
            var formatted = JsonSerializer.Serialize(parsed, new JsonSerializerOptions { WriteIndented = true });

            Json = formatted;
        }
    }
}