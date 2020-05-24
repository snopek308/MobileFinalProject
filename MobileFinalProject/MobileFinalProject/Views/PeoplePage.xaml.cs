using MobileFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileFinalProject.Views
{
    [DesignTimeVisible(false)]
    public partial class PeoplePage : ContentPage
    {
        PeopleViewModel viewModel;
        public PeoplePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PeopleViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.PeopleModels.Count == 0)
                viewModel.LoadPeopleCommand.Execute(null);
        }
    }
}