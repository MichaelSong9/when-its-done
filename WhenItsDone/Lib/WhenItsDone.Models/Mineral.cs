﻿using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Mineral : IDbModel
    {
        [Key]
        public int Id { get; set; }

        [Range(ValidationConstants.QuantityMinValue, ValidationConstants.QuantityMaxValue)]
        public decimal Quantity { get; set; }

        [Required]
        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        [RegularExpression(RegexConstants.EnBgSpaceMinus)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}