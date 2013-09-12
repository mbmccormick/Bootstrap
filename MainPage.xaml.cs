using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using Bootstrap.Common;
using Microsoft.Phone.Tasks;
using System.Windows.Media;

namespace Bootstrap
{
    public partial class MainPage : PhoneApplicationPage
    {
        #region Data Binding Properties

        public static ObservableCollection<string> Items { get; set; }

        #endregion

        private bool isLoaded = false;

        public MainPage()
        {
            InitializeComponent();

            App.UnhandledExceptionHandled += new EventHandler<ApplicationUnhandledExceptionEventArgs>(App_UnhandledExceptionHandled);

            Items = new ObservableCollection<string>();

            this.BuildApplicationBar();
        }

        private void BuildApplicationBar()
        {
            //ApplicationBarIconButton refresh = new ApplicationBarIconButton();
            //refresh.IconUri = new Uri("/Resources/refresh.png", UriKind.RelativeOrAbsolute);
            //refresh.Text = "refresh";
            //refresh.Click += btnRefresh_Click;

            //ApplicationBar.Buttons.Add(add);
            
            ApplicationBarMenuItem about = new ApplicationBarMenuItem();
            about.Text = "about";
            about.Click += mnuAbout_Click;

            ApplicationBar.MenuItems.Add(about);
        }

        private void App_UnhandledExceptionHandled(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                ToggleLoadingText();
                ToggleEmptyText();

                GlobalLoading.Instance.IsLoading = false;
            });
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.IsNavigationInitiator == false)
            {
                LittleWatson.CheckForPreviousException(true);

                if (isLoaded == false)
                    LoadData();
            }
        }

        private void LoadData()
        {
            //GlobalLoading.Instance.IsLoading = true;

            //App.ServiceClient.GetItems((result) =>
            //{
            //    SmartDispatcher.BeginInvoke(() =>
            //    {
            //        Items.Clear();

            //        foreach (string item in result)
            //        {
            //            Items.Add(item);
            //        }

            //        isLoaded = true;

            //        ToggleLoadingText();
            //        ToggleEmptyText();

            //        GlobalLoading.Instance.IsLoading = false;
            //    });
            //});
        }

        private void ToggleLoadingText()
        {
            this.txtLoading.Visibility = System.Windows.Visibility.Collapsed;
            this.lstDefault.Visibility = System.Windows.Visibility.Visible;
        }

        private void ToggleEmptyText()
        {
            if (Items.Count == 0)
                this.txtEmpty.Visibility = System.Windows.Visibility.Visible;
            else
                this.txtEmpty.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            SmartDispatcher.BeginInvoke(() =>
            {
                NavigationService.Navigate(new Uri("/YourLastAboutDialog;component/AboutPage.xaml", UriKind.Relative));
            });
        }
    }
}