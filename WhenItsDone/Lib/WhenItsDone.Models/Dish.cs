﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Dish : IDbModel
    {
        private ICollection<PhotoItem> photoItems;
        private ICollection<WorkerReview> workerReviews;

        public Dish()
        {
            this.photoItems = new HashSet<PhotoItem>();
            this.workerReviews = new HashSet<WorkerReview>();
        }

        [Key]
        public int Id { get; set; }

        [Range(ValidationConstants.RatingMinValue, ValidationConstants.RatingMaxValue)]
        public int Rating { get; set; }

        public int RecipeId { get; set; }

        [Required]
        public virtual Recipe Recipe { get; set; }

        [Range(ValidationConstants.DishPriceMinValue, ValidationConstants.DishPriceMaxValue)]
        public decimal Price { get; set; }

        public virtual ICollection<PhotoItem> PhotoItems
        {
            get
            {
                return this.photoItems;
            }

            set
            {
                this.photoItems = value;
            }
        }

        public virtual ICollection<WorkerReview> WorkerReviews
        {
            get
            {
                return this.workerReviews;
            }

            set
            {
                this.workerReviews = value;
            }
        }

        public bool IsDeleted { get; set; }
    }
}
