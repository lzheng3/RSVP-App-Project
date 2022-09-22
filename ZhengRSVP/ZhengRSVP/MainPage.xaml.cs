using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZhengRSVP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void signButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Adduser());
        }

        private async void loginBtn_Clicked(object sender, EventArgs e)
        {
            string id = username.Text;
            string pw = password.Text;
            DAL dal = new DAL();
            if (dal.AuthenticateUser(id, pw))
            {
                await Navigation.PushAsync(new EventPage());
            }
            else
            {
                errorMessage.TextColor = Color.Red;
                errorMessage.Text = "Login Failed";
            }
        }
    }
}
