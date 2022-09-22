using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZhengRSVP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Adduser : ContentPage
    {
        public Adduser()
        {
            InitializeComponent();
        }

        private void addUserBtn_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(password.Text)
                || string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(phone.Text))
            {
                errorMessage.Text = "Some field is empty. Please try again.";
            }
            else
            {
                User user = new User();
                user.Name = name.Text;
                user.EmailAddress = email.Text;
                user.Password = password.Text;
                user.PhoneNumber = phone.Text;
                DAL dal = new DAL();
                dal.AddUser(user);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await DisplayAlert("Congratulation!", "User Registeration Sucessfull!", "OK", "Cancel");
                    if (result)
                    {
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await Navigation.PushAsync(new MainPage());
                    }
                });
            }
        }

        private void cancelBtn_Clicked(object sender, EventArgs e)
        {
            name.Text = string.Empty;
            password.Text = string.Empty;
            errorMessage.Text = string.Empty;
        }

    }
}