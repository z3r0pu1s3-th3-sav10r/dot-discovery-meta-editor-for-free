using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

#nullable enable
public static class FNV1A
{
  public static ulong Hash(this string name, string[] filter)
  {
    if (string.IsNullOrEmpty(name))
      name = "0";
    if (name.All<char>((Func<char, bool>) (c => c >= '0' && c <= '9')))
      return Convert.ToUInt64(name);
    name = name.Replace('\\', '/');
    int num1 = ((IEnumerable<string>) filter).Select<string, int>((Func<string, int>) (keyword => name.LastIndexOf("/" + keyword + "/"))).Where<int>((Func<int, bool>) (index => index >= 0)).DefaultIfEmpty<int>(-1).Max();
    if (num1 >= 0)
      name = name.Substring(num1 + 1);
    Trace.WriteLine(name);
    byte[] bytes = Encoding.ASCII.GetBytes(name.ToLower());
    ulong num2 = 14695981039346656037;
    for (int index = 0; index < bytes.Length; ++index)
      num2 = (num2 ^ (ulong) bytes[index]) * 1099511628211UL;
    return num2;
  }

  public static ulong Hash(this string name, string[] filter, out string formatted)
  {
    if (string.IsNullOrEmpty(name))
    {
      name = "0";
      formatted = name;
    }
    if (name.All<char>((Func<char, bool>) (c => c >= '0' && c <= '9')))
    {
      formatted = name;
      return Convert.ToUInt64(name);
    }
    name = name.Replace('\\', '/');
    name = Regex.Replace(name, ".dds", ".tex", RegexOptions.IgnoreCase);
    int num1 = ((IEnumerable<string>) filter).Select<string, int>((Func<string, int>) (keyword => name.LastIndexOf("/" + keyword + "/"))).Where<int>((Func<int, bool>) (index => index >= 0)).DefaultIfEmpty<int>(-1).Max();
    if (num1 >= 0)
      name = name.Substring(num1 + 1);
    formatted = name.ToLower();
    byte[] bytes = Encoding.ASCII.GetBytes(name.ToLower());
    ulong num2 = 14695981039346656037;
    for (int index = 0; index < bytes.Length; ++index)
      num2 = (num2 ^ (ulong) bytes[index]) * 1099511628211UL;
    return num2;
  }

  public static ulong HashTexture(this string name, string[] filter)
  {
    if (string.IsNullOrEmpty(name))
      name = "0";
    name = Regex.Replace(name, ".dds", ".tex", RegexOptions.IgnoreCase);
    return name.Hash(filter);
  }
}
