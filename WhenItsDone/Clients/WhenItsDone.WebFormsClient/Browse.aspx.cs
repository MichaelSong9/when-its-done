﻿using System;
using System.Linq;

using WebFormsMvp;
using WebFormsMvp.Web;

using WhenItsDone.Data.EntityDataSourceContainer;
using WhenItsDone.MVP.BrowseMVP;

namespace WhenItsDone.WebFormsClient
{
    [PresenterBinding(typeof(IBrowsePresenter))]
    public partial class Browse : MvpPage<BrowseViewModel>, IBrowseView
    {
        public event EventHandler OnBrowseDishesGetData;

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Dishes> BrowseDishesListViewGetData()
        {
            this.OnBrowseDishesGetData?.Invoke(null, null);

            return this.Model.BrowseDishesViews;
        }
    }
}