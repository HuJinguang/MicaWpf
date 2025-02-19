﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Windows;

namespace Glasssix.MicaUI.Controls
{
    public interface IElementFactoryShim
    {
        UIElement GetElement(ElementFactoryGetArgs args);
        void RecycleElement(ElementFactoryRecycleArgs context);
    }
}