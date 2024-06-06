using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

#nullable enable
namespace Meta.Core.Converters
{
  public class StatusToImageConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (string.IsNullOrEmpty(parameter.ToString().ToUpper()))
        return (object) string.Empty;
      string empty = string.Empty;
      return (object) "FolderAccountOutline";
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
