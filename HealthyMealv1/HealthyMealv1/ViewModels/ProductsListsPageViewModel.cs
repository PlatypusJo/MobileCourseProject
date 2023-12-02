using HealthyMealv1.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HealthyMealv1.ViewModels
{
    public class ProductsListsPageViewModel : BaseViewModel
    {
        private int _pageIndex = 1;
        public int PageIndex
        { 
            get => _pageIndex;
            set { _pageIndex = value; }
        }

        public ObservableCollection<ProductToBuyModel> ProductsToBuy { get; set; }

        public ProductsListsPageViewModel()
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            ProductsToBuy = new ObservableCollection<ProductToBuyModel>()
            {
                new ProductToBuyModel()
                {
                    Id = 1,
                    ProductId = 1,
                    UnitsId = 1,
                    UnitsName = "г",
                    Name = "Сыр",
                    Amount = 100,
                },
                new ProductToBuyModel()
                {
                    Id = 2,
                    ProductId = 2,
                    UnitsId = 2,
                    UnitsName = "мл",
                    Name = "Молоко",
                    Amount = 980,
                },
                new ProductToBuyModel()
                {
                    Id = 3,
                    ProductId = 3,
                    UnitsId = 3,
                    UnitsName = "г",
                    Name = "Колбаса",
                    Amount = 200,
                },
                new ProductToBuyModel()
                {
                    Id = 4,
                    ProductId = 4,
                    UnitsId = 4,
                    UnitsName = "г",
                    Name = "Фарш свиной",
                    Amount = 450,
                },
                new ProductToBuyModel()
                {
                    Id = 4,
                    ProductId = 4,
                    UnitsId = 4,
                    UnitsName = "у.е.",
                    Name = "Test1",
                    Amount = 450,
                },
                new ProductToBuyModel()
                {
                    Id = 4,
                    ProductId = 4,
                    UnitsId = 4,
                    UnitsName = "у.е.",
                    Name = "Test2",
                    Amount = 450,
                }
            };
        }
    }
}
