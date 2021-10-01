﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UniAlumni.DataTier.Common.Enum;

namespace UniAlumni.DataTier.ViewModels.Alumni
{
    public class CreateAlumniRequestBody
    {
        [Required]
        public string Uid { get; set; }
        
        [Required]
        [MinLength(9)]
        [MaxLength(13)]
        public string Phone { get; set; }
        
        [Required]
        [MinLength((6))]
        [MaxLength(50)]
        public string FullName { get; set; }
        
        [MaxLength(200)]
        public string Address { get; set; }
        
        public DateTime DoB { get; set; }
        
        
        public string Job { get; set; }
        
        [MaxLength(200)]
        public string AboutMe { get; set; }
        
        [Required]
        public int? UniversityId { get; set; }
        
        [Required]
        public int? CompanyId { get; set; }
    }
}