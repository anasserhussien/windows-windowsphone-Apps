﻿using my_second_app.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace my_second_app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page2 : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public Page2()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        string technology = "When people are asked to describe inventors, they often use one word: genius. As a society, we look upon the inventor with awe, and we fawn over his inventions with curiosity and admiration. We wonder, how did he do that? Where did he find his inspiration?";
        string photography = "You often don’t or can’t see beauty in the world until someone shows it to you. Take a look around you just now – even without moving from the computer. Can you see something in a new way, a different way of presenting something common? Just take a look again…";
        string painting = "Some painters transform the sun into a yellow spot, others transform a yellow spot into the sun.";
        string graffiti = "Graffiti is one of the few tools you have if you have almost nothing. And even if you don't come up with a picture to cure world poverty you can make someone smile while they're having a piss";

        public people_fill obj = new people_fill();
        
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {

            switch (Phone_Main.first_selection)
            {
                case 0:
                    obj.tech();
                    pageTitle.Text = "Technology";
                  //  left_text.Text = technology;
                    break;

                case 1:
                    obj.gra();
                    pageTitle.Text = "Graffiti";
                  //  left_text.Text = graffiti;
                    break;



                case 2:
                    obj.photo();
                    pageTitle.Text = "Photographing";
                //    left_text.Text = photography;
                    break;


                case 3:
                    obj.painters();
                    pageTitle.Text = "Painting";
                  //  left_text.Text = painting;
                    break;


            }
            mygrid.ItemsSource = obj.people;


        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
        public static int grid_selection;
        private void mygrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grid_selection = mygrid.SelectedIndex; 
            this.Frame.Navigate(typeof(story));
        }
    }
}
