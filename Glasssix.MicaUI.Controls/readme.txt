Thanks for installing the ModernWPF UI NuGet package!

Don't forget to add the theme resources to your Application resources in App.xaml:

    <Application
        ...
        xmlns:ui="http://glasssix.com/winfx/xaml/toolkit/micaui">
        <Application.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                    <ui:ThemeResources />
                    <ui:XamlControlsResources />
                    <!-- Other merged dictionaries here -->
                </ResourceDictionary.MergedDictionaries>
                <!-- Other app resources here -->
            </ResourceDictionary>
        </Application.Resources>
    </Application>

To enable themed style for a window, set WindowHelper.UseModernWindowStyle to true:

    <Window
        ...
        xmlns:ui="http://glasssix.com/winfx/xaml/toolkit/micaui"
        ui:WindowHelper.UseModernWindowStyle="True">
        <!-- Window content here -->
    </Window>

See https://github.com/Kinnara/Glasssix.MicaUI for more information.
