
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalHerbs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
            this.BackgroundImageSource = App.bgImage;
            labelAbout.Text = "Данная программа содержит рецепты лечения болезней народными срадствами взятыми из книги 'Сборник по народной медицине Минеджян Г. З.'";
            labelAutor.Text = "Разработчик: Сергей Новиков \n e-mail: dolphincodestudio@gmail.com";

        }
    }
}