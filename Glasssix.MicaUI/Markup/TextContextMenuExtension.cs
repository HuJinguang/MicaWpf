using Glasssix.MicaUI.Controls;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Glasssix.MicaUI.Markup
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [MarkupExtensionReturnType(typeof(ContextMenu))]
    public class TextContextMenuExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return DefaultContextMenu.Value;
        }

        private static readonly ThreadLocal<TextContextMenu> DefaultContextMenu = new ThreadLocal<TextContextMenu>(() => new TextContextMenu());
    }
}
