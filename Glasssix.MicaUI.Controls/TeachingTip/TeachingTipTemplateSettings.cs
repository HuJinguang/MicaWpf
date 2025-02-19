﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Glasssix.MicaUI.Controls
{
    public class TeachingTipTemplateSettings : DependencyObject
    {
        internal TeachingTipTemplateSettings()
        {
        }

        #region IconElement

        public static readonly DependencyProperty IconElementProperty =
            DependencyProperty.Register(
                nameof(IconElement),
                typeof(IconElement),
                typeof(TeachingTipTemplateSettings));

        public IconElement IconElement
        {
            get => (IconElement)GetValue(IconElementProperty);
            set => SetValue(IconElementProperty, value);
        }

        #endregion

        #region TopLeftHighlightMargin

        public static readonly DependencyProperty TopLeftHighlightMarginProperty =
            DependencyProperty.Register(
                nameof(TopLeftHighlightMargin),
                typeof(Thickness),
                typeof(TeachingTipTemplateSettings));

        public Thickness TopLeftHighlightMargin
        {
            get => (Thickness)GetValue(TopLeftHighlightMarginProperty);
            set => SetValue(TopLeftHighlightMarginProperty, value);
        }

        #endregion

        #region TopRightHighlightMargin

        public static readonly DependencyProperty TopRightHighlightMarginProperty =
            DependencyProperty.Register(
                nameof(TopRightHighlightMargin),
                typeof(Thickness),
                typeof(TeachingTipTemplateSettings));

        public Thickness TopRightHighlightMargin
        {
            get => (Thickness)GetValue(TopRightHighlightMarginProperty);
            set => SetValue(TopRightHighlightMarginProperty, value);
        }

        #endregion
    }
}
