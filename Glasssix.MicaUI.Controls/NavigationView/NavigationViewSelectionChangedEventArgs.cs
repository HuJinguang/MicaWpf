﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using Glasssix.MicaUI.Media.Animation;

namespace Glasssix.MicaUI.Controls
{
    public sealed class NavigationViewSelectionChangedEventArgs : EventArgs
    {
        internal NavigationViewSelectionChangedEventArgs()
        {
        }

        public object SelectedItem { get; internal set; }
        public bool IsSettingsSelected { get; internal set; }

        public NavigationViewItemBase SelectedItemContainer { get; internal set; }
        public NavigationTransitionInfo RecommendedNavigationTransitionInfo { get; internal set; }
    }
}
