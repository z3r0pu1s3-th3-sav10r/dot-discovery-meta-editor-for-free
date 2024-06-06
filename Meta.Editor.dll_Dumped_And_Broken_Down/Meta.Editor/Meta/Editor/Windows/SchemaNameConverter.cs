using System;
using System.Globalization;
using System.Windows.Data;

#nullable enable
namespace Meta.Editor.Windows
{
  public class SchemaNameConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value is string str ? (object) str.Split('_')[0] : value;
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
