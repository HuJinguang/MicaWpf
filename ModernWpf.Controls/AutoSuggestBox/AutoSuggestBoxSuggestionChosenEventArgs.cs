using System;
using System.Windows;

namespace Glasssix.MicaUI.Controls
{
    public sealed class AutoSuggestBoxSuggestionChosenEventArgs : EventArgs
    {
        public AutoSuggestBoxSuggestionChosenEventArgs()
        {
        }

        public object SelectedItem { get; internal set; }
    }
}
