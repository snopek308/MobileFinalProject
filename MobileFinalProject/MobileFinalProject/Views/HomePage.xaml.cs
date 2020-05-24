using MobileFinalProject.Models;
using MobileFinalProject.Services;
using MobileFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileFinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public List<PeopleModel> PeopleModels { get; set; }
        public List<ShipModel> ShipModels { get; set; }
        public SwHomePageVm swHomePageVm { get; set; }
        public HomePage()
        {
            InitializeComponent();
        }

        private async void SwBtn_Click(object sender, EventArgs e)
        {
            await PostResultsAsync();
        }

        public async Task PostResultsAsync()
        {
            Random random = new Random();
            SWApiService apiService = new SWApiService(new HttpClient());
            PeopleModels = new List<PeopleModel>();
            ShipModels = new List<ShipModel>();

            var people = await apiService.GetPeople("people");
            foreach (var person in people)
            {
                PeopleModels.Add(person);
            }

            var starships = await apiService.GetShips("starships");
            foreach (var ship in starships)
            {
                ShipModels.Add(ship);
            }

            SwHomePageVm swHomePageVm = new SwHomePageVm();
            swHomePageVm.name = PeopleModels[random.Next(1, 10)].name;
            swHomePageVm.ship = ShipModels[random.Next(1, 10)].name;

            var result = "You are " + swHomePageVm.name + " flying the " + swHomePageVm.ship + ".";
            answer.Text = result;
        }
    }
}