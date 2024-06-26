﻿using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO.ServiceDTO
{
    public class ServiceAddRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Cost is required.")]
        public double? Cost { get; set; }

    }
}
