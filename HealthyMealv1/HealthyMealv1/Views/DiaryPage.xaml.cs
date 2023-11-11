using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthyMealv1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthyMealv1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiaryPage : ContentPage
    {
        public DiaryPage()
        {
            InitializeComponent();
            this.BindingContext = new DiaryPageViewModel();
        }
    }
}