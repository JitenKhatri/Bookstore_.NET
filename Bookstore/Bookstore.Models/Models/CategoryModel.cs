﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Models.ViewModels;

namespace Bookstore.Models.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {

        }
        public CategoryModel(Category category) {

            Id = category.Id;
            Name = category.Name; 
            }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
