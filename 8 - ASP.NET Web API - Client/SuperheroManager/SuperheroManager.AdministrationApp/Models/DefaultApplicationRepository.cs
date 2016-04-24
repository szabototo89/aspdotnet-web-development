using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SuperheroManager.AdministrationApp.Annotations;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.AdministrationApp.Models
{
    public class DefaultApplicationRepository : IApplicationRepository, IDisposable
    {
        private readonly String baseAddress;
        private HttpClient client;

        public DefaultApplicationRepository(String baseAddress)
        {
            if (baseAddress == null) throw new ArgumentNullException(nameof(baseAddress));
            this.baseAddress = baseAddress;

            InitializeHttpClient(baseAddress);
        }

        private void InitializeHttpClient(String baseAddress)
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Superhero>> GetSuperheroesAsync()
        {
            HttpResponseMessage response = await client.GetAsync("api/superhero");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"An error has been occured during fetching superheroes from server: {response.StatusCode.ToString()}");
            }

            var superheroes = await response.Content.ReadAsAsync<IEnumerable<Superhero>>();
            return superheroes;
        }

        public async Task<Int32> CreateSuperheroAsync(Superhero superhero)
        {
            if (superhero == null) throw new ArgumentNullException(nameof(superhero));

            var response = await client.PostAsJsonAsync("api/superhero", superhero);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"An error has been occured during adding a new superhero: {response.StatusCode}");
            }

            var id = await response.Content.ReadAsAsync<Int32>();
            return id;
        }

        public async Task RemoveSuperheroAsync(Superhero selectedSuperhero)
        {
            if (selectedSuperhero == null) throw new ArgumentNullException(nameof(selectedSuperhero));
            var response = await client.DeleteAsync($"api/superhero/{selectedSuperhero.Id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"An error has been occured during removing the selected superhero");
            }
        }

        public async Task<Superhero> UpdateSuperheroAsync(Int32 id, Superhero value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            var response = await client.PutAsJsonAsync($"api/superhero/{value.Id}", value);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("An error has been occured during updating the selected superhero");
            }

            return await response.Content.ReadAsAsync<Superhero>();
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
