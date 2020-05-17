using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MobileFinalProject.Models;
using MobileFinalProject.Views;
using MobileFinalProject.Services;
using System.Net.Http;
using System.Collections.Generic;

namespace MobileFinalProject.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public List<ShipModel> ShipModels { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Star Wars Ships";
            ShipModels = new List<ShipModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                SWApiService swApiService = new SWApiService(new HttpClient());
                var items = await swApiService.GetShips("starships");
                foreach (var item in items)
                {
                    ShipModels.Add(item);
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