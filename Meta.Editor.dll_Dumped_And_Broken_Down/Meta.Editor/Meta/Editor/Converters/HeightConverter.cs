using System;

#nullable disable
namespace Meta.Editor.Converters
{
  public static class HeightConverter
  {
    private static readonly double baseHeight = 1.5;
    private static readonly double scalingFactor = 2100.0;
    private static readonly int baseValue = 3135;

    public static (int minValue, int maxValue) CalculateValueRange(double heightInMeters)
    {
      double num = (heightInMeters - HeightConverter.baseHeight) * HeightConverter.scalingFactor + (double) HeightConverter.baseValue;
      return ((int) Math.Floor(num), (int) Math.Ceiling(num));
    }

    public static double ConvertValueToHeight(int value)
    {
      return Math.Floor(((double) (value - HeightConverter.baseValue) / HeightConverter.scalingFactor + HeightConverter.baseHeight) * 100.0) / 100.0;
    }
  }
}
