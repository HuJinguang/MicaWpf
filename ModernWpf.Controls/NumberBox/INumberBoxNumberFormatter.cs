namespace Glasssix.MicaUI.Controls
{
    public interface INumberBoxNumberFormatter
    {
        string FormatDouble(double value);
        double? ParseDouble(string text);
    }
}
