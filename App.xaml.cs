using MedicalHerbs.Data;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace MedicalHerbs
{
    public partial class App : Application
    {
        public static ImageSource bgImage = ImageSource.FromResource("MedicalHerbs.Resources.bgmainpage.png", typeof(MainPage).GetTypeInfo().Assembly);

        static LocalDatabase database;
        public List<string> diseaseList = new List<string>();
        //создаем новую локальную базу данных на устройстве

        public static LocalDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new LocalDatabase("medherbs2.db3");
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage()) { Style = (Style)Application.Current.Resources["navigationPage"] };
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}