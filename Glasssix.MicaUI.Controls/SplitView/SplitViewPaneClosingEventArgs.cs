using System;

namespace Glasssix.MicaUI.Controls
{
    public sealed class SplitViewPaneClosingEventArgs : EventArgs
    {
        internal SplitViewPaneClosingEventArgs()
        {
        }

        public bool Cancel { get; set; }
    }
}