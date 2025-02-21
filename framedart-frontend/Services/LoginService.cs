using framedart_frontend.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace framedart_frontend.Services {

    public interface ILoginService {
        Task<LoginResponse> Login (LoginUserDTO user);
    }

    public class LoginService : ILoginService {

        public static string end = "https://localhost:7201/api";

        public async Task<LoginResponse> Login(LoginUserDTO user)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = cookieContainer
            };

            using (HttpClient client = new HttpClient(handler))
            {
                try
                {
                    string url = $"{end}/Account/login";
                    string json = JsonConvert.SerializeObject(user);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Adicionando a flag para enviar cookies
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    var response = await client.PostAsync(url, content);
                    string responseData = await response.Content.ReadAsStringAsync();

                    var jsonResponse = JsonConvert.DeserializeObject<LoginResponse>(responseData);

                    if (jsonResponse?.Success != true)
                        return jsonResponse;

                    var response2 = await client.GetAsync($"{end}/Customer");
                    var responseData2 = await response2.Content.ReadAsStringAsync();

                    if (!response2.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Falha ao acessar /Customer: {response2.StatusCode}");
                    }

                    return jsonResponse;
                }
                catch (Exception e)
                {
                    return new LoginResponse { Success = false, Message = $"Erro interno no servidor. Detalhes: {e.Message}" };
                }
            }

        }


    }
}