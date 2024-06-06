using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;

#nullable enable
namespace Meta.Editor.Controls
{
  public class NullToZeroConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      ICollection collection;
      int num;
      if (value != null)
      {
        collection = value as ICollection;
        num = collection == null ? 1 : 0;
      }
      else
        num = 1;
      return num != 0 ? (object) 0 : (object) collection.Count;
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
