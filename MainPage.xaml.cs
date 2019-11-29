using System;
using System.ComponentModel;
using Xamarin.Forms;





namespace MedicalHerbs
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {

            InitializeComponent();
            this.BackgroundImageSource = App.bgImage;



        }

        async private void ButtonListOfDiseases_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeseasesView());

        }


        async private void ButtonAbout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }

        async private void ButtonFavorites_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavoritesView());
        }

        async private void ButtonExit_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Выход из приложения!", "Вы действительно хотите закрыть приложение?", "Да", "Нет"))
            { Android.OS.Process.KillProcess(Android.OS.Process.MyPid()); }

        }
    }
}
