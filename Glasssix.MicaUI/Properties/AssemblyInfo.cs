using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
                                     //(used if a resource is not found in the page,
                                     // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
                                              //(used if a resource is not found in the page,
                                              // app, or any theme specific resource dictionaries)
)]

[assembly: InternalsVisibleTo("Glasssix.MicaUI.Controls")]
[assembly: InternalsVisibleTo("Glasssix.MicaUI.MahApps")]
[assembly: InternalsVisibleTo("MUXControlsTestApp")]

[assembly: XmlnsPrefix("http://glasssix.com/winfx/xaml/toolkit/micaui", "ui")]
[assembly: XmlnsDefinition("http://glasssix.com/winfx/xaml/toolkit/micaui", "Glasssix.MicaUI")]
[assembly: XmlnsDefinition("http://glasssix.com/winfx/xaml/toolkit/micaui", "Glasssix.MicaUI.Controls")]
[assembly: XmlnsDefinition("http://glasssix.com/winfx/xaml/toolkit/micaui", "Glasssix.MicaUI.Controls.Primitives")]
[assembly: XmlnsDefinition("http://glasssix.com/winfx/xaml/toolkit/micaui", "Glasssix.MicaUI.DesignTime")]
[assembly: XmlnsDefinition("http://glasssix.com/winfx/xaml/toolkit/micaui", "Glasssix.MicaUI.Markup")]
[assembly: XmlnsDefinition("http://glasssix.com/winfx/xaml/toolkit/micaui", "Glasssix.MicaUI.Media")]
[assembly: XmlnsDefinition("http://glasssix.com/winfx/xaml/toolkit/micaui", "Glasssix.MicaUI.Media.Animation")]
