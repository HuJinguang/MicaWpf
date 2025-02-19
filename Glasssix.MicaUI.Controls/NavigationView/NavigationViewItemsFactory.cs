﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Glasssix.MicaUI.Controls
{
    class NavigationViewItemsFactory : ElementFactory
    {
        public void UserElementFactory(object newValue)
        {
            m_itemTemplateWrapper = newValue as IElementFactoryShim;
            if (m_itemTemplateWrapper == null)
            {
                // ItemTemplate set does not implement IElementFactoryShim. We also 
                // want to support DataTemplate and DataTemplateSelectors automagically.
                if (newValue is DataTemplate dataTemplate)
                {
                    m_itemTemplateWrapper = new ItemTemplateWrapper(dataTemplate);
                }
                else if (newValue is DataTemplateSelector selector)
                {
                    m_itemTemplateWrapper = new ItemTemplateWrapper(selector);
                }
            }

            navigationViewItemPool = new List<NavigationViewItem>();
        }

        internal void SettingsItem(NavigationViewItemBase settingsItem)
        {
            m_settingsItem = settingsItem;
        }


        // Retrieve the element that will be displayed for a specific data item.
        // If the resolved element is not derived from NavigationViewItemBase, wrap in a NavigationViewItem before returning.
        protected override UIElement GetElementCore(ElementFactoryGetArgs args)
        {
            object newContent;
            {
                object init()
                {
                    // Do not template SettingsItem
                    if (m_settingsItem != null && m_settingsItem == args.Data)
                    {
                        return args.Data;
                    }

                    if (m_itemTemplateWrapper != null)
                    {
                        return m_itemTemplateWrapper.GetElement(args);
                    }
                    return args.Data;
                }
                newContent = init();
            }

            // Element is already of expected type, just return it
            if (newContent is NavigationViewItemBase newItem)
            {
                return newItem;
            }

            // Get or create a wrapping container for the data
            NavigationViewItem nvi;
            {
                nvi = init();
                NavigationViewItem init()
                {
                    if (navigationViewItemPool.Count > 0)
                    {
                        var nvi = navigationViewItemPool.Last();
                        navigationViewItemPool.RemoveLast();
                        return nvi;
                    }
                    return new NavigationViewItem();
                }
            }
            var nviImpl = nvi;
            nviImpl.CreatedByNavigationViewItemsFactory = true;

            // If a user provided item template exists, just pass the template and data down to the ContentPresenter of the NavigationViewItem
            if (m_itemTemplateWrapper != null)
            {
                if (m_itemTemplateWrapper is ItemTemplateWrapper itemTemplateWrapper)
                {
                    // Recycle newContent
                    var tempArgs = new ElementFactoryRecycleArgs();
                    tempArgs.Element = newContent as UIElement;
                    m_itemTemplateWrapper.RecycleElement(tempArgs);


                    nviImpl.Content = args.Data;
                    nviImpl.ContentTemplate = itemTemplateWrapper.Template;
                    nviImpl.ContentTemplateSelector = itemTemplateWrapper.TemplateSelector;
                    return nviImpl;
                }
            }

            nviImpl.Content = newContent;
            return nviImpl;
        }

        protected override void RecycleElementCore(ElementFactoryRecycleArgs args)
        {
            if (args.Element is { } element)
            {
                if (element is NavigationViewItem nvi)
                {
                    var nviImpl = nvi;
                    // Check whether we wrapped the element in a NavigationViewItem ourselves.
                    // If yes, we are responsible for recycling it.
                    if (nviImpl.CreatedByNavigationViewItemsFactory)
                    {
                        nviImpl.CreatedByNavigationViewItemsFactory = false;
                        UnlinkElementFromParent(args);
                        args.Element = null;

                        // Retain the NVI that we created for future re-use
                        navigationViewItemPool.Add(nvi);

                        // Retrieve the proper element that requires recycling for a user defined item template
                        // and update the args correspondingly
                        if (m_itemTemplateWrapper != null)
                        {
                            // TODO: Retrieve the element and add to the args
                        }
                    }
                }

                // Do not recycle SettingsItem
                bool isSettingsItem = m_settingsItem != null && m_settingsItem == args.Element;

                if (m_itemTemplateWrapper != null && !isSettingsItem)
                {
                    m_itemTemplateWrapper.RecycleElement(args);
                }
                else
                {
                    UnlinkElementFromParent(args);
                }
            }
        }

        void UnlinkElementFromParent(ElementFactoryRecycleArgs args)
        {
            // We want to unlink the containers from the parent repeater
            // in case we are required to move it to a different repeater.
            if (args.Parent is Panel panel)
            {
                var children = panel.Children;
                int childIndex = 0;
                if (children.IndexOf(args.Element, out childIndex))
                {
                    children.RemoveAt(childIndex);
                }
            }
        }

        IElementFactoryShim m_itemTemplateWrapper;
        NavigationViewItemBase m_settingsItem;
        List<NavigationViewItem> navigationViewItemPool = new List<NavigationViewItem>();
    }
}
