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
            Vehicle vehicle = new Vehicle(10, "Forrd", "Junker", 20);
        }

        private HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("https://vpic.nhtsa.dot.gov/api/")
        };

        //public async Task<bool> IsValidModelForMakeAsyn()
        //{
        //    var make = this.Make;
        //    var model = this.Model;
        //    string urlSiffix = $"/vehicles/GetModelsForMake{Make}/?format=json";
        //    var response = await _client.GetAsync(urlSiffix);
        //    var rawJaon = await response.Content.ReadAsStringAsync();
        //    var data = JsonSerializer.Deserialize<IsValidModelForMakeAsync>(rawJaon);
        //     return data.result.Any(r => r.Model_Name == Model);
        //}

        public async Task<bool> WasModelMadeInYearAsync(int year)
        {
            var make = this.Make;
            var model = this.Model;
            if (year < 1995) throw new System.ArgumentException(" No data is available for years before 1995.");
            string urlSiffix = $"vehicles/getmodelsformakeyear/make/{Make}/modelyear/{year}?format=json";
            var response = await _client.GetAsync(urlSiffix);
            var rawJaon = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<GetModelsForMakeYearResponseModel>(rawJaon);
            return data.result.Any(r => r.Model_Name == Model);
        }

        public void AddPassengers(int PassengersToAdd)
        {
            NumberOfPassengers = NumberOfPassengers + PassengersToAdd;
            MilesPerGallon = MilesPerGallon - (PassengersToAdd * .2);
        }

        public void RemovePassengers(int PassengersToRemove)
        {
            NumberOfPassengers = NumberOfPassengers - PassengersToRemove;
            if (NumberOfPassengers < 0)
                ExcessPassengers = PassengersToRemove - NumberOfPassengers;
                PassengersToRemove = PassengersToRemove - ExcessPassengers;

            MilesPerGallon = MilesPerGallon - (PassengersToRemove * .2);
        }
    }
}
