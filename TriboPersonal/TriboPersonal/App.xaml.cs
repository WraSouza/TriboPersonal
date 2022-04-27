using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriboPersonal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new View.LoginView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
