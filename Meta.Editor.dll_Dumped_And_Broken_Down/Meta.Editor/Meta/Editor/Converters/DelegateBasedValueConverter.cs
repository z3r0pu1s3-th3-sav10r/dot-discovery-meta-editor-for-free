using System;
using System.Globalization;
using System.Windows.Data;

#nullable enable
namespace Meta.Editor.Converters
{
  public class DelegateBasedValueConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (parameter == null || !(parameter is Func<object, object>))
        throw new ArgumentException("\"parameter\" is null or not of the type \"Func<object, object>\".");
      return ((Func<object, object>) parameter)(value);
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
