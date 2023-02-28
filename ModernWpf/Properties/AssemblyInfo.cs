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

[assembly: XmlnsPrefix("http://schemas.modernwpf.com/2019", "ui")]
[assembly: XmlnsDefinition("http://schemas.modernwpf.com/2019", "Glasssix.MicaUI")]
[assembly: XmlnsDefinition("http://schemas.modernwpf.com/2019", "Glasssix.MicaUI.Controls")]
[assembly: XmlnsDefinition("http://schemas.modernwpf.com/2019", "Glasssix.MicaUI.Controls.Primitives")]
[assembly: XmlnsDefinition("http://schemas.modernwpf.com/2019", "Glasssix.MicaUI.DesignTime")]
[assembly: XmlnsDefinition("http://schemas.modernwpf.com/2019", "Glasssix.MicaUI.Markup")]
[assembly: XmlnsDefinition("http://schemas.modernwpf.com/2019", "Glasssix.MicaUI.Media")]
[assembly: XmlnsDefinition("http://schemas.modernwpf.com/2019", "Glasssix.MicaUI.Media.Animation")]
