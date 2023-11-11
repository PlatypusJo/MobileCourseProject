using HealthyMealv1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthyMealv1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealsPage : ContentPage
    {
        public MealsPage()
        {
            InitializeComponent();
            BindingContext = new MealsPageViewModel();
        }
    }
}