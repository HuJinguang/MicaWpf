﻿using Glasssix.MicaUI.SampleApp.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Glasssix.MicaUI.SampleApp.ControlPages
{
    /// <summary>
    /// FlipViewPage.xaml 的交互逻辑
    /// </summary>
    public partial class FlipViewPage : ItemsPageBase
    {
        public FlipViewPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Items = ControlInfoDataSource.Instance.Groups.Take(3).SelectMany(g => g.Items).ToList();
        }
    }
}
