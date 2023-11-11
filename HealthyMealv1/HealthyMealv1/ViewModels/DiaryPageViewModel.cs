using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HealthyMealv1.Views;

namespace HealthyMealv1.ViewModels
{
    public class DiaryPageViewModel : BaseViewModel
    {
        public ICommand OpenMealsPageCommand { get; private set; }

        public DiaryPageViewModel() 
        {
            OpenMealsPageCommand = new Command(OnPlusButtonClick);
        }

        public async void OnPlusButtonClick()
        {
            await Shell.Current.GoToAsync($"//{nameof(MealsPage)}");
        }
    }
}
