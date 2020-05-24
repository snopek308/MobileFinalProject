using MobileFinalProject.Models;
using MobileFinalProject.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileFinalProject.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {
        public List<PeopleModel> PeopleModels { get; set; }
        public Command LoadPeopleCommand { get; set; }

        public PeopleViewModel()
        {
            Title = "Star Wars People";
            PeopleModels = new List<PeopleModel>();
            LoadPeopleCommand = new Command(async () => await ExecuteLoadPeopleCommand());
        }

        async Task ExecuteLoadPeopleCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                SWApiService swApiService = new SWApiService(new HttpClient());
                var people = await swApiService.GetPeople("people");
                foreach (var person in people)
                {
                    PeopleModels.Add(person);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
