﻿using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO.RoleDTO
{
    public class RoleAddRequest
    {
        [Required(ErrorMessage = "Must enter a valid ID")]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "Must enter a Role Name")]
        public string? Name { get; set; }
        public Role toRole()
        {
            return new Role { 
                RoleId = RoleId,
                Name = Name 
            };
        }
        
    }
}
