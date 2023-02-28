using System.Windows;

namespace Glasssix.MicaUI.Controls
{
    public class GridViewHeaderItem : ListViewBaseHeaderItem
    {
        static GridViewHeaderItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GridViewHeaderItem), new FrameworkPropertyMetadata(typeof(GridViewHeaderItem)));
        }

        public GridViewHeaderItem()
        {
        }
    }
}
