using HealthyMealv1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HealthyMealv1.ViewModels
{
    public class FoodPageViewModel : BaseViewModel
    {
        public ICommand GoBackCommand { get; private set; }

        public FoodPageViewModel()
        {
            GoBackCommand = new Command(OnGoBackButtonClick);
        }

        public async void OnGoBackButtonClick()
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
