using MedicalHerbs.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalHerbs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesView : ContentPage
    {

        public List<Disease> diseaseList = new List<Disease>();
        public FavoritesView()
        {
            InitializeComponent();
            this.BackgroundImageSource = App.bgImage;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            diseaseList = await App.Database.GetFavoriteAsync();
            listView.ItemsSource = diseaseList;


        }

        private async void ListView_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                await Navigation.PushAsync(new DiseasesViewDetail(e.Item as Disease));
            }
        }


    }
}