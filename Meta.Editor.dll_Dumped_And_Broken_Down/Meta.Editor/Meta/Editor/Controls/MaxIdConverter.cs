using System;
using System.Globalization;
using System.Windows.Data;

#nullable enable
namespace Meta.Editor.Controls
{
  public class MaxIdConverter : IValueConverter
  {
    private bool hasOverride = false;

    public MaxIdConverter(bool _hasOverride) => this.hasOverride = _hasOverride;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value is uint num ? (object) (uint) ((int) num + 1) : value;
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      return value;
    }
  }
}
