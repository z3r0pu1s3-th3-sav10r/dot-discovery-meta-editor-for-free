using System;
using System.Collections.ObjectModel;
using System.Linq;

#nullable enable
namespace Meta.Editor.Controls
{
  public static class JObjectExtensions
  {
    public static JObject Get<T>(this ObservableCollection<JObject> table, object inputType)
    {
      if (typeof (T) == typeof (byte))
        return table.Where<JObject>((Func<JObject, bool>) (s => ((byte) (long) s.Id).Equals(inputType))).FirstOrDefault<JObject>();
      if (typeof (T) == typeof (ushort))
        return table.Where<JObject>((Func<JObject, bool>) (s => ((ushort) (long) s.Id).Equals(inputType))).FirstOrDefault<JObject>();
      return typeof (T) == typeof (uint) ? table.Where<JObject>((Func<JObject, bool>) (s => ((uint) (long) s.Id).Equals(inputType))).FirstOrDefault<JObject>() : (JObject) null;
    }

    public static JObjectCrowdSign Get<T>(
      this ObservableCollection<JObjectCrowdSign> table,
      object inputType)
    {
      return typeof (T) == typeof (uint) ? table.Where<JObjectCrowdSign>((Func<JObjectCrowdSign, bool>) (s => ((uint) (long) s.Id).Equals(inputType))).FirstOrDefault<JObjectCrowdSign>() : (JObjectCrowdSign) null;
    }
  }
}
