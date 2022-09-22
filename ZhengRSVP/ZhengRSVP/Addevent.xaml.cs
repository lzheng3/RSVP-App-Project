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
    public partial class Addevent : ContentPage
    {
        public Addevent()
        {
            InitializeComponent();
            
        }

        private async void saveBtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(person.Text) || string.IsNullOrEmpty(eventName.Text) 
                || string.IsNullOrEmpty(location.Text) || string.IsNullOrEmpty(max.Text))
            {
                errorMessage.Text = "Some field is empty please try again.";
            }
            else
            {
                Event myevent = new Event();
                myevent.HostPerson = person.Text;
                myevent.Eventname = eventName.Text;
                myevent.Eventaddress = location.Text;
                myevent.Maxpeople = max.Text;
                myevent.Eventdate = eventDate.Date;
                myevent.Deadline = deadline.Date;
                DAL dal = new DAL();
                dal.AddEvent(myevent);
                
                await Navigation.PushAsync(new EventPage());
            }
        }

        private void cancelBtn_Clicked(object sender, EventArgs e)
        {
            eventName.Text = string.Empty;
            location.Text = string.Empty;
            errorMessage.Text = string.Empty;
        }
    }
}