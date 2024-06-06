using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;

#nullable enable
namespace Meta.Editor.Extensions
{
  public class TextExtension : MarkupExtension
  {
    private readonly string textFile;

    public TextExtension(string inTextFile) => this.textFile = inTextFile;

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      using (Stream stream = Application.GetResourceStream(new Uri("pack://application:,,,/" + this.textFile)).Stream)
      {
        using (TextReader textReader = (TextReader) new StreamReader(stream))
          return (object) textReader.ReadToEnd();
      }
    }
  }
}
