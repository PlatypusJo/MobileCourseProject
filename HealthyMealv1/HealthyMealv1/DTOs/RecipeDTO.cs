﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HealthyMealv1.DTOs
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public ObservableCollection<StepDTO> StepsCooking { get; set; }
        public ObservableCollection<IngredientDTO> Ingredients { get; set; }
    }
}