﻿using System;

using Bytes2you.Validation;

using WebFormsMvp;

using WhenItsDone.Services.Contracts;

namespace WhenItsDone.MVP.DetailsMVP
{
    public class DetailsPresenter : Presenter<IDetailsView>, IDetailsPresenter
    {
        private readonly IDishesAsyncService dishesAsyncService;

        public DetailsPresenter(IDetailsView view, IDishesAsyncService dishesAsyncService)
            : base(view)
        {
            Guard.WhenArgument(dishesAsyncService, nameof(IDishesAsyncService)).IsNull().Throw();

            this.dishesAsyncService = dishesAsyncService;

            base.View.OnGetDishDetails += this.OnGetDishDetails;
            base.View.OnLikeVote += this.OnLikeVote;
            base.View.OnDislikeVote += this.OnDislikeVote;
        }

        private void OnLikeVote(object sender, DetailsRatingVoteEventArgs args)
        {
            Guard.WhenArgument(args, nameof(DetailsGetDishDetailsEventArgs)).IsNull().Throw();

            int dishId;
            if (!int.TryParse(args.DishId, out dishId))
            {
                throw new ArgumentException("Invalid Dish Id");
            }

            base.View.Model.DishRating = this.dishesAsyncService.ChangeDishRating(dishId, 1);
        }


        private void OnDislikeVote(object sender, DetailsRatingVoteEventArgs args)
        {
            Guard.WhenArgument(args, nameof(DetailsGetDishDetailsEventArgs)).IsNull().Throw();

            int dishId;
            if (!int.TryParse(args.DishId, out dishId))
            {
                throw new ArgumentException("Invalid Dish Id");
            }

            base.View.Model.DishRating = this.dishesAsyncService.ChangeDishRating(dishId, -1);
        }

        private void OnGetDishDetails(object sender, DetailsGetDishDetailsEventArgs args)
        {
            Guard.WhenArgument(args, nameof(DetailsGetDishDetailsEventArgs)).IsNull().Throw();

            int dishId;
            if (!int.TryParse(args.DishId, out dishId))
            {
                throw new ArgumentException("Invalid Dish Id");
            }

            base.View.Model.DishDetails = this.dishesAsyncService.GetDishDetailsViewById(dishId);
            base.View.Model.DishRating = this.View.Model.DishDetails.Rating;
        }
    }
}
