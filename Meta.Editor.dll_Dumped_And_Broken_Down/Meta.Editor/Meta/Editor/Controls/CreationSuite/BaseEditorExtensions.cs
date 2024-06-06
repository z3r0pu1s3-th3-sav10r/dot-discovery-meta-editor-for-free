using System;
using System.Linq.Expressions;
using System.Reflection;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  public static class BaseEditorExtensions
  {
    public static TValue Get<T, TValue>(
      this T editor,
      Expression<Func<T, TValue>> propertyExpression)
      where T : BaseEditor
    {
      PropertyInfo member;
      int num;
      if (propertyExpression.Body is MemberExpression body)
      {
        member = body.Member as PropertyInfo;
        num = member != null ? 1 : 0;
      }
      else
        num = 0;
      if (num != 0)
      {
        object obj1 = member.GetValue((object) editor);
        if (obj1 == null)
          return (TValue) new JObject((object) 0L, "null");
        if (obj1 is TValue obj2)
          return obj2;
      }
      throw new ArgumentException("Invalid property expression", nameof (propertyExpression));
    }
  }
}
