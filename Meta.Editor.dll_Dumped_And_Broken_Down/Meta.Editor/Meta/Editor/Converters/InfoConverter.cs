using Meta.WWE2K23;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

#nullable enable
namespace Meta.Editor.Converters
{
  public class InfoConverter : JsonConverter
  {
    public override bool CanConvert(Type objectType) => objectType == typeof (Info);

    public override object? ReadJson(
      JsonReader reader,
      Type objectType,
      object? existingValue,
      JsonSerializer serializer)
    {
      JObject jobject = JObject.Load(reader);
      Info target = new Info();
      serializer.Populate(jobject.CreateReader(), (object) target);
      if (jobject["billed_from"] != null)
        target.location_callname = jobject["billed_from"].Value<uint>();
      if (jobject["payback_1"] != null)
        target.payback_01 = jobject["payback_1"].Value<byte>();
      if (jobject["payback_2"] != null)
        target.payback_02 = jobject["payback_2"].Value<byte>();
      return (object) target;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
      Info info = (Info) value;
      JObject jobject = new JObject();
      serializer.Converters.Remove((JsonConverter) this);
      jobject.Add("location_callname", JToken.FromObject((object) info.location_callname, serializer));
      jobject.Add("payback_01", JToken.FromObject((object) info.payback_01, serializer));
      jobject.Add("payback_02", JToken.FromObject((object) info.payback_02, serializer));
      foreach (PropertyInfo property in typeof (Info).GetProperties())
      {
        if (property.Name != "billed_from")
          jobject.Add(property.Name, JToken.FromObject(property.GetValue((object) info), serializer));
        else if (property.Name != "payback_1")
          jobject.Add(property.Name, JToken.FromObject(property.GetValue((object) info), serializer));
        else if (property.Name != "payback_2")
          jobject.Add(property.Name, JToken.FromObject(property.GetValue((object) info), serializer));
      }
      jobject.WriteTo(writer);
    }
  }
}
