using System;
using System.Globalization;
using System.Windows.Data;

#nullable enable
namespace Meta.Editor.Controls
{
  public class ToUpperConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value == null ? (object) null : (object) value.ToString().ToUpper(culture);
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      throw new NotSupportedException("ConvertBack is not supported in ToUpperConverter");
    }
  }
}
