using System;
using System.Collections.Generic;

#nullable enable
public static class Extensions
{
  public static byte[] ToByteArray(this List<uint> uintList)
  {
    byte[] dst = new byte[uintList.Count * 4];
    Buffer.BlockCopy((Array) uintList.ToArray(), 0, (Array) dst, 0, dst.Length);
    return dst;
  }

  public static byte[] ToByteArray(this List<ushort> ushortList)
  {
    byte[] byteArray = new byte[ushortList.Count * 2];
    for (int index = 0; index < ushortList.Count; ++index)
    {
      byte[] bytes = BitConverter.GetBytes(ushortList[index]);
      byteArray[index * 2] = bytes[0];
      byteArray[index * 2 + 1] = bytes[1];
    }
    return byteArray;
  }

  public static byte[] ToByteArray(this List<byte> uintList)
  {
    byte[] dst = new byte[uintList.Count * 4];
    Buffer.BlockCopy((Array) uintList.ToArray(), 0, (Array) dst, 0, dst.Length);
    return dst;
  }
}
