using Glasssix.MicaUI.Controls;
using System;

namespace Glasssix.MicaUI.SampleApp.Common
{

    public class CategoryBase { }

    public class Category : CategoryBase
    {
        public string Name { get; set; }
        public string Tooltip { get; set; }
        public Symbol Glyph { get; set; }
        //public Type TargetType { get; set; }
    }

    public class Separator : CategoryBase { }

    public class Header : CategoryBase
    {
        public string Name { get; set; }
    }
}
