using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ClothesStore.View;

namespace ClothesStore
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var signInView = new SignIn();
            signInView.Show();
            signInView.IsVisibleChanged += (s, ev) =>
            {
                if (signInView.IsVisible == false && signInView.IsLoaded)
                {
                    var userView = new UserView();
                    userView.Show();
                    signInView.Close();
                }
            };
        }
    }
}
