using System.Dynamic;
using System.Text.Json;

namespace CodeLouisvilleUnitTestProject
{
    public class Car : Vehicle
    {

        public int NumberOfPassengers { get; private set; }

        public Car()
            : this(0, "", "", 0)
        { }

        public Car(double gasTankCapacity, string make, string model, double milesPerGallon)
        {

        }

        private HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("https://vpic.nhtsa.dot.gov/api/")
        };

    }
        public async Task<bool> WasModelMadeInYearAsync(int year)
        {
            var make = this.Make;
            var model = this.Model;
            if (year < 1995) throw new System.ArgumentException(" No data is available for years before 1995.");
            string urlSiffix = $"vehicles/getmodelsformakeyear/make/{Make}/modelyear/{year}?format=json";
            var response = await _client.GetAsync(urlSiffix);
            var rawJaon = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<GetModelsForMakeYearResponseModel>(rawJson);
            return data.results.Any(r => r.Model_Name == Model);

        }
    }
}
