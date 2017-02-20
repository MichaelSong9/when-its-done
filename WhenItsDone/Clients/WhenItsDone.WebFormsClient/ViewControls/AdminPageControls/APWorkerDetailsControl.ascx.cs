﻿using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using WhenItsDone.MVP.AdminPageControls.APWorkerDetailsControlMVP;
using WhenItsDone.MVP.AdminPageControls.EventArguments;

namespace WhenItsDone.WebFormsClient.ViewControls.AdminPageControls
{
    [PresenterBinding(typeof(APWorkerDetailsPresenter))]
    public partial class APWorkerDetails : MvpUserControl<APWorkerDetailsControlViewModel>, IAPWorkerDetailsControlView
    {
        public event EventHandler<StringEventArgs> GetWorkerDetailsById;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetWorkersFireEvent(StringEventArgs args)
        {
            this.GetWorkerDetailsById?.Invoke(this, args);
        }

        protected void OnEdit(object sender, EventArgs e)
        {

        }
    }
}