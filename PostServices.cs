using CommunityToolkit.Mvvm.Collections;
using HTTPClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTPClient.Services
{
    public class PostServices
    {
        internal async Task<ObservableCollection<Post>> getPosts()
        {
            throw new NotImplementedException();
        }

        private class Postservices
        {
            private HttpClient _httpClient;
            private Post post;
            private ObservableCollection<Post> posts;
            private HttpClient httpClient;
            private JsonSerializerOptions jsonSerializerOptions;


            public Postservices()
            {
                httpClient = new HttpClient();
                jsonSerializerOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

            }

            public async Task<ObservableCollection<Post>>getPosts()
            {
                Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");
                List<Post> itens = new List<Post>();

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        itens = JsonSerializer.Deserialize<List<Post>>(content, jsonSerializerOptions);
                    }
                }
                catch(Exception ex)
                {
                 
                }
                return itens;
            }


        }
    }
}
