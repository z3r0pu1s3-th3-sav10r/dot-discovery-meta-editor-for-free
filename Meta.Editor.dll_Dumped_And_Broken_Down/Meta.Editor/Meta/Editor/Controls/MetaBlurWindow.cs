using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

#nullable enable
namespace Meta.Editor.Controls
{
  public class MetaBlurWindow : Window
  {
    [DllImport("user32.dll")]
    internal static extern int SetWindowCompositionAttribute(
      IntPtr hwnd,
      ref WindowCompositionAttributeData data);

    static MetaBlurWindow()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (MetaBlurWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (MetaBlurWindow)));
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) => this.EnableBlur();

    internal void EnableBlur()
    {
      WindowInteropHelper windowInteropHelper = new WindowInteropHelper((Window) this);
      AccentPolicy structure = new AccentPolicy();
      int cb = Marshal.SizeOf<AccentPolicy>(structure);
      structure.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;
      IntPtr num = Marshal.AllocHGlobal(cb);
      Marshal.StructureToPtr<AccentPolicy>(structure, num, false);
      MetaBlurWindow.SetWindowCompositionAttribute(windowInteropHelper.Handle, ref new WindowCompositionAttributeData()
      {
        Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
        SizeOfData = cb,
        Data = num
      });
      Marshal.FreeHGlobal(num);
    }
  }
}
