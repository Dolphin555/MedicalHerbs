using MedicalHerbs.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalHerbs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeseasesView : ContentPage
    {
        public List<Disease> diseaseList = new List<Disease>();
        public DeseasesView()
        {
            InitializeComponent();
            this.BackgroundImageSource = App.bgImage;

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            diseaseList = await App.Database.GetNotesAsync();
            listView.ItemsSource = diseaseList;
            SearchValue.Text = "";
        }




        //Поиск по списке болезней по первым буквам
        private void SearchValue_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                listView.ItemsSource = diseaseList;
            }
            else
            {
                listView.ItemsSource = SearchFunc.GetSearchStringInListDiseases(e.NewTextValue, diseaseList);
            }

        }


        //событие при выборе значения из списка болезней.
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                await Navigation.PushAsync(new DiseasesViewDetail(e.Item as Disease));
            }
        }
    }
}