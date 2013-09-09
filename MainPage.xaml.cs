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
        #region List Properties

        public static ObservableCollection<string> Items { get; set; }

        #endregion

        private bool isLoaded = false;

        public MainPage()
        {
            InitializeComponent();

            App.UnhandledExceptionHandled += new EventHandler<ApplicationUnhandledExceptionEventArgs>(App_UnhandledExceptionHandled);

            Items = new ObservableCollection<string>();
        }

        private void App_UnhandledExceptionHandled(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                ToggleLoadingText();
                ToggleEmptyText();

                this.prgLoading.Visibility = System.Windows.Visibility.Collapsed;
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
            //this.prgLoading.Visibility = System.Windows.Visibility.Visible;

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

            //        this.prgLoading.Visibility = System.Windows.Visibility.Collapsed;
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
    }
}