﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Models.ViewModels;

namespace Bookstore.Models.Models
{
    public class RoleModel
    {
        public RoleModel() { }

        public RoleModel(Role role)
        {
            Id = role.Id;
            Name = role.Name;

        }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
