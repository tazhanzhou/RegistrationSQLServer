﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationSQLServer
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void EnterInfoButton_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BusinessLayer.UserInformation userInfo = new BusinessLayer.UserInformation();
                //send the user info to the database
                userInfo.FirstName = Server.HtmlEncode(firstNameTextBox.Text);
                userInfo.LastName = Server.HtmlEncode(lastNameTextBox.Text);
                userInfo.Address = Server.HtmlEncode(addressTextBox.Text);
                userInfo.City = Server.HtmlEncode(cityTextBox.Text);
                userInfo.Province = Server.HtmlEncode(stateOrProvinceTextBox.Text);
                userInfo.PostalCode = Server.HtmlEncode(zipCodeTextBox.Text);
                userInfo.Country = Server.HtmlEncode(countryTextBox.Text);

                if (DBLayer.DBUtilities.InsertUserInformation(userInfo) == 1)
                {
                    this.lblResultMessage.Text = "The User Information " +
                        "was successfully inserted into the table";
                    btnGoEdit.Visible = true;
                }
                else this.lblResultMessage.Text = "There was an error on " +
                        "inserting the user informaiton!";
            }
        }

        protected void btnGoEdit_Click(object sender, EventArgs e)
        {
            string urlAddress = $"EditUserInformationById.aspx?userId=" +
                $"{DBLayer.DBUtilities.getInsertedUserId()}";
            this.Response.Redirect(urlAddress);
        }
    }
}