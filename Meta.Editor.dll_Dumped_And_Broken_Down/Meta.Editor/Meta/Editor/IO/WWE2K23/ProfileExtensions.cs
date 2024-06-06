using Meta.Core.IO;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace Meta.Editor.IO.WWE2K23
{
  public static class ProfileExtensions
  {
    public static object ReadMemory<T>(
      NativeReader reader,
      Dictionary<string, int> dictionary,
      string key)
    {
      int num;
      if (dictionary.TryGetValue(key, out num))
      {
        if (typeof (T) == typeof (ushort))
        {
          reader.Position = (long) Convert.ToUInt32(num);
          return (object) reader.ReadUShort((Endian) 0);
        }
        if (typeof (T) == typeof (uint))
        {
          reader.Position = (long) Convert.ToUInt32(num);
          return (object) reader.ReadUInt((Endian) 0);
        }
        if (typeof (T) == typeof (byte))
        {
          reader.Position = (long) Convert.ToUInt32(num);
          return (object) reader.ReadByte();
        }
      }
      return (object) default (T);
    }

    public static object ReadMemoryArray<T>(
      NativeReader reader,
      Dictionary<string, int> dictionary,
      string key,
      int count)
    {
      int num;
      if (dictionary.TryGetValue(key, out num))
      {
        if (typeof (T) == typeof (List<byte>))
        {
          reader.Position = (long) Convert.ToUInt32(num);
          return (object) ((IEnumerable<byte>) reader.ReadByteArray(count)).ToList<byte>();
        }
        if (typeof (T) == typeof (List<uint>))
        {
          reader.Position = (long) Convert.ToUInt32(num);
          return (object) ((IEnumerable<uint>) reader.ReadUIntArray(count)).ToList<uint>();
        }
      }
      return (object) default (T);
    }
  }
}
