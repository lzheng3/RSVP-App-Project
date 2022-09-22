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
    public partial class EventPage : ContentPage
    {
        
        public EventPage()
        {
            InitializeComponent();
            DAL dal = new DAL();
            lvEvent.ItemsSource = dal.GetAllEvent();
        }

        private async void nextBtn2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RSVP());
        }

        private async void addEventBtn_Clicked(object sender, EventArgs e)
        {
            DAL dal = new DAL();
            lvEvent.ItemsSource = dal.GetAllEvent();
            await Navigation.PushAsync(new Addevent());
          
        }

        private void myCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}