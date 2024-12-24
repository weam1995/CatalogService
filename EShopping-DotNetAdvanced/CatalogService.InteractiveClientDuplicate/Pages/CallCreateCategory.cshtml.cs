using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatalogService.Interactive.Pages
{
    public class CallCreateCategoryModel(IHttpClientFactory httpClientFactory) : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            // Example endpoint URL
            string url = "https://localhost:7182/api/categories";

            // Create a new object to send in the POST request
            var postData = new { name = "Weam christmas market", imageurl = "www.christmasmarket.com" };

            // Serialize the object to JSON
            var jsonData = JsonSerializer.Serialize(postData);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Make the POST request
            var client = httpClientFactory.CreateClient("apiClient");
            var response = await client.PostAsync(url, content);

            // Check if the response is successful
            if (response.IsSuccessStatusCode)
            {
                // Optionally handle the response
                var responseData = await response.Content.ReadAsStringAsync();
                // ViewData["ResponseCode"] = response.StatusCode;
                ViewData["Response"] = responseData; // Store response data to show in the view
                return Page();
            }

            // Handle errors appropriately (e.g., log the error)
            string errorMsg = $"Error posting data. {(int)response.StatusCode} {response.ReasonPhrase}";
            ModelState.AddModelError("", errorMsg);
            ViewData["ErrorMessage"] = errorMsg;
            return Page();
        }
    }
}