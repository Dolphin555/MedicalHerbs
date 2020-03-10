using MedicalHerbs.Models;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalHerbs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiseasesViewDetail : ContentPage
    {

        public bool starClick;
        public Disease disease;

        public DiseasesViewDetail(Disease disease)
        {
            InitializeComponent();
            this.disease = disease;
            this.BackgroundImageSource = App.bgImage;
            LabelDiseaseName.Text = disease.Name;
            Title = disease.Name;
            LabelDiseaseDetail.Text = FilesData.ReaderFiletoText(string.Concat("MedicalHerbs.DiseasesFiles.", disease.Name, ".txt"));
            StatusFavorite(disease);

        }

        public void StatusFavorite(Disease d)
        {
            if (d.Favorite)
            {
                favoriteItem.IconImageSource = ImageSource.FromResource("MedicalHerbs.Icon.starYellow.png", 
                    typeof(DiseasesViewDetail).GetTypeInfo().Assembly);
            }
            else
            {
                favoriteItem.IconImageSource = ImageSource.FromResource("MedicalHerbs.Icon.starWhite.png", 
                    typeof(DiseasesViewDetail).GetTypeInfo().Assembly);
            }
        }

        private void favoriteItem_Clicked(object sender, EventArgs e)
        {
            if (disease.Favorite)
            {
                disease.Favorite = false;
                App.Database.SaveNoteAsync(disease);
                favoriteItem.IconImageSource = ImageSource.FromResource("MedicalHerbs.Icon.starWhite.png", typeof(DiseasesViewDetail).GetTypeInfo().Assembly);


            }
            else
            {
                disease.Favorite = true;
                App.Database.SaveNoteAsync(disease);
                favoriteItem.IconImageSource = ImageSource.FromResource("MedicalHerbs.Icon.starYellow.png", typeof(DiseasesViewDetail).GetTypeInfo().Assembly);
            }

        }
    }



}