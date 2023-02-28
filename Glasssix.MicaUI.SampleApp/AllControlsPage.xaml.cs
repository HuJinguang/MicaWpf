﻿using Glasssix.MicaUI.Controls;
using Glasssix.MicaUI.SampleApp.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Glasssix.MicaUI.SampleApp
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public partial class AllControlsPage : ItemsPageBase
    {
        public AllControlsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var menuItem = NavigationRootPage.Current.NavigationView.MenuItems.Cast<NavigationViewItem>().ElementAt(1);
            menuItem.IsSelected = true;
            NavigationRootPage.Current.NavigationView.Header = string.Empty;

            Items = ControlInfoDataSource.Instance.Groups.SelectMany(g => g.Items).OrderBy(i => i.Title).ToList();
            DataContext = Items;
        }
    }
}
