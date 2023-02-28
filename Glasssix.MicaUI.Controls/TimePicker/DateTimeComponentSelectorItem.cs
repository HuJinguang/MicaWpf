using System.Windows;
using System.Windows.Controls;

namespace Glasssix.MicaUI.Controls
{
    public class DateTimeComponentSelectorItem : ListBoxItem
    {
        static DateTimeComponentSelectorItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DateTimeComponentSelectorItem), new FrameworkPropertyMetadata(typeof(DateTimeComponentSelectorItem)));
        }
    }
}
