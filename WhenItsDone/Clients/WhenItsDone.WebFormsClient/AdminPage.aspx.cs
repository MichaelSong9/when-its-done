﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WhenItsDone.MVP.AdminPageControls.EventArguments;

namespace WhenItsDone.WebFormsClient
{
    public partial class AdminPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.APWorkersControl.UserClickedInfoButton += ContactInformationRequired;
        }

        protected void ContactsButtonWasClicked(object sender, EventArgs e)
        {
            this.ContactInformationRequired(sender, null);
        }

        protected void ContactInformationRequired(object sender, StringEventArgs e)
        {
            if (e == null)
            {
                e = new StringEventArgs(this.hiddenIdField.Text);
            }

            if (e.StringParameter == null)
            {
                e.StringParameter = this.hiddenIdField.Text;
            }
            else
            {
                this.hiddenIdField.Text = e.StringParameter;
            }

            this.APWorkerDetailsControl.GetWorkersFireEvent(e);

            this.HideAllControlsOnThatPage();
            this.RemoveActiveForAllButtons();

            this.APWorkerDetailsControl.Visible = true;
            this.buttons.Visible = true;
            this.ContactsBtn.CssClass += " grey lighten-2";
        }

        protected void BackToAllWorkersClicked(object sender, EventArgs e)
        {
            this.APWorkersControl.GetWorkersFireEvent();

            this.HideAllControlsOnThatPage();
            this.RemoveActiveForAllButtons();

            this.APWorkersControl.Visible = true;
        }

        private void HideAllControlsOnThatPage()
        {
            this.APWorkersControl.Visible = false;
            this.APWorkerDetailsControl.Visible = false;
            this.buttons.Visible = false;
        }

        private void RemoveActiveForAllButtons()
        {
            var defaultBtnStyles = "waves-effect waves-light btn";

            this.BackToAll.CssClass = defaultBtnStyles;
            this.ContactsBtn.CssClass = defaultBtnStyles;
            this.MedicalBtn.CssClass = defaultBtnStyles;
            this.DishesBtn.CssClass = defaultBtnStyles;
        }

        protected void MedicalBtnWasClicked(object sender, EventArgs e)
        {
            this.HideAllControlsOnThatPage();
            this.RemoveActiveForAllButtons();

            this.buttons.Visible = true;
            this.MedicalBtn.CssClass += " grey lighten-2";
        }

        protected void DishesBtnWasClicked(object sender, EventArgs e)
        {
            this.HideAllControlsOnThatPage();
            this.RemoveActiveForAllButtons();

            this.buttons.Visible = true;
            this.DishesBtn.CssClass += " grey lighten-2";
        }
    }
}