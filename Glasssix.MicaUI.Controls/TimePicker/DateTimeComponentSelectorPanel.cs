﻿using System.Windows.Controls;

namespace Glasssix.MicaUI.Controls
{
    public class DateTimeComponentSelectorPanel : VirtualizingStackPanel
    {
        public override void MouseWheelUp()
        {
            LineUp();
        }

        public override void MouseWheelDown()
        {
            LineDown();
        }
    }
}
