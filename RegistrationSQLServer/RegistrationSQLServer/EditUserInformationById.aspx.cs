using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationSQLServer
{
    public partial class EditUserInformationById : System.Web.UI.Page
    {
        int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            userId = int.Parse(Request.QueryString["userId"]);
            BusinessLayer.UserInformation userInformation = DBLayer.DBUtilities.SelectUserInformationById(userId);
            if (!Page.IsPostBack)
            {
                firstNameTextBox.Text = userInformation.FirstName;
                lastNameTextBox.Text = userInformation.LastName;
                addressTextBox.Text = userInformation.Address;
                cityTextBox.Text = userInformation.City;
                stateOrProvinceTextBox.Text = userInformation.Province;
                zipCodeTextBox.Text = userInformation.PostalCode;
                countryTextBox.Text = userInformation.Country;
            }

        }

        protected void updateInfoButton_Click(object sender, EventArgs e)
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

            if (DBLayer.DBUtilities.UpdateUserInformationById(userId, userInfo) == 1)
            {
                this.lblResultMessage.Text = "The User Information " +
                    "was successfully updated";
            }
            else this.lblResultMessage.Text = "There was an error on " +
                    "inserting the user informaiton!";
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Registration.aspx");
        }
    }
}