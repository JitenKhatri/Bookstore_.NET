﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Models.Models;
using Bookstore.Models.ViewModels;

namespace Bookstore.Repository
{
    public class RoleRepository : BaseRepository
    {
        public ListResponse<Role> GetRoles()
        {
            var query = _context.Roles.AsQueryable();
            var totalRecords = query.Count();
            IEnumerable<Role> role = query;
            return new ListResponse<Role>()
            {
                Results = role,
                TotalRecords = totalRecords
            };
        }

    }
}
