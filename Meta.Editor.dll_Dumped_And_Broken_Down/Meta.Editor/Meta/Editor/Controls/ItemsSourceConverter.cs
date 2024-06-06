using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

#nullable enable
namespace Meta.Editor.Controls
{
  public class ItemsSourceConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value is IEnumerable enumerable && enumerable != null ? (object) new CollectionViewSource()
      {
        Source = ((object) enumerable)
      }.View : throw new Exception("Value must be an IEnumerable");
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      return DependencyProperty.UnsetValue;
    }
  }
}
