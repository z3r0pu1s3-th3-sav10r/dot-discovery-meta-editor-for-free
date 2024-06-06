using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shell;

#nullable enable
namespace Meta.Editor.Controls
{
  [TemplatePart(Name = "PART_ResizeBorder", Type = typeof (Border))]
  [TemplatePart(Name = "PART_WindowBorder", Type = typeof (Border))]
  [TemplatePart(Name = "PART_LayoutGrid", Type = typeof (Grid))]
  [TemplatePart(Name = "PART_HeaderRowDefinition", Type = typeof (RowDefinition))]
  [TemplatePart(Name = "PART_HeaderColumnDefinition", Type = typeof (ColumnDefinition))]
  [TemplatePart(Name = "PART_HeaderBorder", Type = typeof (Border))]
  [TemplatePart(Name = "PART_ContentBorder", Type = typeof (Border))]
  [TemplatePart(Name = "PART_TitleBar", Type = typeof (Panel))]
  [TemplatePart(Name = "PART_Close", Type = typeof (Button))]
  [TemplatePart(Name = "PART_Minimize", Type = typeof (Button))]
  [TemplatePart(Name = "PART_Maximize", Type = typeof (Button))]
  [TemplatePart(Name = "PART_Icon", Type = typeof (Image))]
  [TemplatePart(Name = "PART_Title", Type = typeof (TextBlock))]
  [TemplatePart(Name = "PART_Drag", Type = typeof (Control))]
  public class MetaWindow : Window
  {
    private Button minimizeButton;
    private Button maximizeButton;
    private Button closeButton;
    private Image iconImage;
    private Control dragControl;
    public static readonly DependencyProperty ResizeBorderWidthProperty = DependencyProperty.Register(nameof (ResizeBorderWidth), typeof (int), typeof (MetaWindow), new PropertyMetadata((object) 6));
    public static readonly DependencyProperty EnableDropShadowProperty = DependencyProperty.Register(nameof (EnableDropShadow), typeof (bool), typeof (MetaWindow), new PropertyMetadata((object) true));
    public static readonly DependencyProperty DropShadowBlurRadiusProperty = DependencyProperty.Register(nameof (DropShadowBlurRadius), typeof (int), typeof (MetaWindow), new PropertyMetadata((object) 10));
    public static readonly DependencyProperty DropShadowOpacityProperty = DependencyProperty.Register(nameof (DropShadowOpacity), typeof (double), typeof (MetaWindow), new PropertyMetadata((object) 1.0));
    public static readonly DependencyProperty DropShadowColorProperty = DependencyProperty.Register(nameof (DropShadowColor), typeof (Color), typeof (MetaWindow), new PropertyMetadata((object) Colors.Black));
    public static readonly DependencyProperty IsDraggingProperty = DependencyProperty.Register(nameof (IsDragging), typeof (bool), typeof (MetaWindow), new PropertyMetadata((object) false));
    private const int WM_WINDOWPOSCHANGING = 70;
    private const int WM_WINDOWPOSCHANGED = 71;
    private const int SWP_NOSIZE = 1;
    private const int SWP_NOMOVE = 2;
    private const int WM_GETMINMAXINFO = 36;
    private const int MONITOR_DEFAULTTONEAREST = 2;
    private const int WM_SIZE = 5;
    private const int SIZE_RESTORED = 0;
    private const int SIZE_MINIMIZED = 1;
    private const int SIZE_MAXIMIZED = 2;
    private const int WM_MOUSEMOVE = 512;

    public event EventHandler MetaLoaded;

    static MetaWindow()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (MetaWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (MetaWindow)));
    }

    public int ResizeBorderWidth
    {
      get => (int) this.GetValue(MetaWindow.ResizeBorderWidthProperty);
      set => this.SetValue(MetaWindow.ResizeBorderWidthProperty, (object) value);
    }

    public bool EnableDropShadow
    {
      get => (bool) this.GetValue(MetaWindow.EnableDropShadowProperty);
      set => this.SetValue(MetaWindow.EnableDropShadowProperty, (object) value);
    }

    public int DropShadowBlurRadius
    {
      get => (int) this.GetValue(MetaWindow.DropShadowBlurRadiusProperty);
      set => this.SetValue(MetaWindow.DropShadowBlurRadiusProperty, (object) value);
    }

    public double DropShadowOpacity
    {
      get => (double) this.GetValue(MetaWindow.DropShadowOpacityProperty);
      set => this.SetValue(MetaWindow.DropShadowOpacityProperty, (object) value);
    }

    public Color DropShadowColor
    {
      get => (Color) this.GetValue(MetaWindow.DropShadowColorProperty);
      set => this.SetValue(MetaWindow.DropShadowColorProperty, (object) value);
    }

    public bool IsDragging
    {
      get => (bool) this.GetValue(MetaWindow.IsDraggingProperty);
      set => this.SetValue(MetaWindow.IsDraggingProperty, (object) value);
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.DetachFromVisualTree();
      this.AttachToVisualTree();
    }

    private void DetachFromVisualTree()
    {
      if (this.closeButton != null)
        this.closeButton.Click -= new RoutedEventHandler(this.OnCloseButtonClick);
      if (this.minimizeButton != null)
        this.minimizeButton.Click -= new RoutedEventHandler(this.OnMinimizeButtonClick);
      if (this.maximizeButton != null)
        this.maximizeButton.Click -= new RoutedEventHandler(this.OnMaximizeButtonClick);
      if (this.iconImage != null)
        this.iconImage.MouseDown -= new MouseButtonEventHandler(this.OnTitleAreaMouseDown);
      if (this.dragControl == null)
        return;
      this.dragControl.MouseMove -= new MouseEventHandler(this.OnDragControlMouseMove);
      this.dragControl.MouseRightButtonDown -= new MouseButtonEventHandler(this.OnTitleAreaMouseDown);
      this.dragControl.MouseDoubleClick -= new MouseButtonEventHandler(this.OnDragControlMouseDoubleClick);
    }

    private void AttachToVisualTree()
    {
      this.closeButton = this.GetChildControl<Button>("PART_Close");
      if (this.closeButton != null)
        this.closeButton.Click += new RoutedEventHandler(this.OnCloseButtonClick);
      this.minimizeButton = this.GetChildControl<Button>("PART_Minimize");
      if (this.minimizeButton != null)
        this.minimizeButton.Click += new RoutedEventHandler(this.OnMinimizeButtonClick);
      this.maximizeButton = this.GetChildControl<Button>("PART_Maximize");
      if (this.maximizeButton != null)
        this.maximizeButton.Click += new RoutedEventHandler(this.OnMaximizeButtonClick);
      this.iconImage = this.GetChildControl<Image>("PART_Icon");
      if (this.iconImage != null)
        this.iconImage.MouseDown += new MouseButtonEventHandler(this.OnTitleAreaMouseDown);
      this.dragControl = this.GetChildControl<Control>("PART_Drag");
      if (this.dragControl != null)
      {
        this.dragControl.MouseMove += new MouseEventHandler(this.OnDragControlMouseMove);
        this.dragControl.MouseRightButtonDown += new MouseButtonEventHandler(this.OnTitleAreaMouseDown);
        this.dragControl.MouseDoubleClick += new MouseButtonEventHandler(this.OnDragControlMouseDoubleClick);
      }
      Border childControl1 = this.GetChildControl<Border>("PART_WindowBorder");
      RowDefinition childControl2 = this.GetChildControl<RowDefinition>("PART_HeaderRowDefinition");
      if (childControl2 != null)
      {
        double num1 = childControl1 != null ? childControl1.BorderThickness.Top : 0.0;
        double num2 = childControl1 != null ? childControl1.BorderThickness.Bottom : 0.0;
        this.MinHeight = Math.Max(this.MinHeight, MetaWindow.GetResizeBorderWidth(this) * 2.0 + childControl2.MinHeight + num1 + num2);
      }
      ColumnDefinition childControl3 = this.GetChildControl<ColumnDefinition>("PART_HeaderColumnDefinition");
      if (childControl3 == null)
        return;
      double num3 = childControl1 != null ? childControl1.BorderThickness.Left : 0.0;
      double num4 = childControl1 != null ? childControl1.BorderThickness.Right : 0.0;
      this.MinWidth = Math.Max(this.MinWidth, MetaWindow.GetResizeBorderWidth(this) * 2.0 + childControl3.MinWidth + num3 + num4);
    }

    protected T GetChildControl<T>(string name) where T : DependencyObject
    {
      return this.GetTemplateChild(name) as T;
    }

    private void OnDragControlMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      if (this.ResizeMode == ResizeMode.NoResize || this.ResizeMode == ResizeMode.CanMinimize)
        return;
      if (this.IsSnapped)
      {
        Rect restoreBounds = this.RestoreBounds;
        this.Top = restoreBounds.Top;
        restoreBounds = this.RestoreBounds;
        this.Left = restoreBounds.Left;
        restoreBounds = this.RestoreBounds;
        this.Width = restoreBounds.Width;
        restoreBounds = this.RestoreBounds;
        this.Height = restoreBounds.Height;
      }
      else
      {
        this.ToggleMaximize();
        this.IsMaximizing = this.WindowState == WindowState.Maximized;
      }
    }

    private bool IsSnapped { get; set; }

    private bool IsMaximizing { get; set; }

    private bool SystemMenuShown { get; set; }

    public void OnCloseButtonClick(object sender, RoutedEventArgs e) => this.Close();

    public void OnMinimizeButtonClick(object sender, RoutedEventArgs e)
    {
      this.WindowState = WindowState.Minimized;
    }

    public void OnMaximizeButtonClick(object sender, RoutedEventArgs e) => this.ToggleMaximize();

    private void ToggleMaximize()
    {
      this.IsSnapped = false;
      if (this.WindowState == WindowState.Maximized)
      {
        this.WindowState = WindowState.Normal;
      }
      else
      {
        MetaWindow.DisableResizeBorder((Window) this);
        this.WindowState = WindowState.Maximized;
      }
    }

    public void OnTitleAreaMouseDown(object sender, MouseButtonEventArgs e)
    {
      Point position = e.GetPosition((IInputElement) null);
      if (e.ChangedButton == MouseButton.Right)
      {
        this.ShowSystemMenu((Window) this, new Point?(position));
        this.SystemMenuShown = true;
      }
      else
      {
        if (e.ChangedButton != MouseButton.Left)
          return;
        if (e.ClickCount == 2)
        {
          this.Close();
        }
        else
        {
          this.ShowSystemMenu((Window) this, new Point?(position));
          this.SystemMenuShown = true;
        }
      }
    }

    public void OnDragControlMouseMove(object sender, MouseEventArgs e)
    {
      this.OnMouseMove(e);
      if (e.LeftButton == MouseButtonState.Pressed && !this.IsMaximizing && !this.SystemMenuShown)
      {
        double opacity = this.Opacity;
        if (this.WindowState == WindowState.Maximized)
        {
          Point position = e.GetPosition((IInputElement) null);
          Point screen1 = this.PointToScreen(position);
          MetaWindow.MonitorArea monitorArea = MetaWindow.GetMonitorArea(new WindowInteropHelper((Window) this).EnsureHandle());
          Point screen2 = this.PointToScreen(e.GetPosition((IInputElement) this.dragControl));
          double actualWidth = this.dragControl.ActualWidth;
          double num1 = screen1.X - screen2.X;
          double num2 = (double) monitorArea.Work.Width - actualWidth - num1;
          Rect restoreBounds = this.RestoreBounds;
          double num3 = Math.Round((restoreBounds.Width - num1 - num2) * position.X / actualWidth);
          double resizeBorderWidth = MetaWindow.GetResizeBorderWidth(this);
          double num4 = (double) monitorArea.Work.Left - resizeBorderWidth;
          double num5 = (double) (monitorArea.Work.Left + monitorArea.Work.Width) + resizeBorderWidth;
          double num6 = num4;
          restoreBounds = this.RestoreBounds;
          double width1 = restoreBounds.Width;
          double num7 = num6 + width1 - num2;
          double num8 = num5;
          restoreBounds = this.RestoreBounds;
          double width2 = restoreBounds.Width;
          double num9 = num8 - width2 + num1;
          Point point = new Point(0.0, resizeBorderWidth);
          if (screen1.X < num7)
          {
            this.Left = num4;
            point.X = resizeBorderWidth;
          }
          else if (screen1.X > num9)
          {
            double num10 = num5;
            restoreBounds = this.RestoreBounds;
            double width3 = restoreBounds.Width;
            this.Left = num10 - width3;
            point.X = -resizeBorderWidth;
          }
          else if (screen1.X > num7 && screen1.X < num9)
            this.Left = screen1.X - num3 - num1 - resizeBorderWidth;
          this.Top = screen1.Y - position.Y;
          this.Left += point.X;
          this.WindowState = WindowState.Normal;
          this.Left -= point.X;
          this.Top -= point.Y;
        }
        this.IsDragging = true;
        MetaWindow.HideDropShadow(this);
        this.DragMove();
        this.IsDragging = false;
        MetaWindow.ShowDropShadow(this);
        this.Opacity = opacity;
      }
      this.IsMaximizing = false;
      this.SystemMenuShown = false;
      e.Handled = true;
    }

    public MetaWindow()
    {
      MethodInfo method = ((object) this).GetType().GetMethod("InitializeComponent", BindingFlags.Instance | BindingFlags.Public);
      if (method != (MethodInfo) null)
        method.Invoke((object) this, (object[]) null);
      MetaWindow.SetChromeWindow((Window) this);
      MetaWindow.SetCustomWindow(this);
      HwndSource.FromHwnd(new WindowInteropHelper((Window) this).EnsureHandle());
      this.ContentRendered += (EventHandler) ((sender, e) =>
      {
        EventHandler metaLoaded = this.MetaLoaded;
        if (metaLoaded == null)
          return;
        metaLoaded(sender, e);
      });
    }

    private static void SetCustomWindow(MetaWindow window)
    {
      window.WindowStyle = WindowStyle.None;
      window.BorderBrush = (Brush) Brushes.Transparent;
      window.AllowsTransparency = true;
      window.SnapsToDevicePixels = true;
    }

    protected override void OnActivated(EventArgs e)
    {
      MetaWindow.ShowDropShadow(this);
      base.OnActivated(e);
    }

    protected override void OnDeactivated(EventArgs e)
    {
      MetaWindow.HideDropShadow(this);
      base.OnDeactivated(e);
    }

    private static void SetChromeWindow(Window window)
    {
      WindowChrome.SetWindowChrome(window, new WindowChrome()
      {
        GlassFrameThickness = new Thickness(0.0),
        CornerRadius = new CornerRadius(0.0),
        CaptionHeight = 0.0
      });
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      HwndSource.FromHwnd(new WindowInteropHelper((Window) this).Handle).RemoveHook(new HwndSourceHook(MetaWindow.WindowHookProc));
      this.DetachFromVisualTree();
      base.OnClosing(e);
    }

    [DllImport("user32")]
    private static extern bool GetMonitorInfo(IntPtr hMonitor, MetaWindow.MONITORINFO lpmi);

    [DllImport("user32")]
    private static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

    private static IntPtr WindowHookProc(
      IntPtr hWnd,
      int msg,
      IntPtr wParam,
      IntPtr lParam,
      ref bool handled)
    {
      MetaWindow window = MetaWindow.GetWindow(hWnd) as MetaWindow;
      switch (msg)
      {
        case 5:
          switch ((int) wParam)
          {
            case 0:
              MetaWindow.MonitorArea monitorArea1 = MetaWindow.GetMonitorArea(hWnd);
              if (monitorArea1 != null)
              {
                int num = (int) lParam & (int) ushort.MaxValue;
                if ((int) ((long) (int) lParam & 4294901760L) >> 16 == monitorArea1.Work.Height || (double) num >= SystemParameters.VirtualScreenWidth)
                {
                  window.IsSnapped = true;
                  MetaWindow.UpdateResizeBorder((Window) window, monitorArea1, window.Left, window.Left + (double) num);
                }
                else
                {
                  window.IsSnapped = false;
                  MetaWindow.ShowDropShadow(window);
                  MetaWindow.EnableResizeBorder((Window) window);
                }
                break;
              }
              break;
            case 2:
              MetaWindow.DisableResizeBorder((Window) window);
              break;
          }
          break;
        case 36:
          MetaWindow.MonitorArea monitorArea2 = MetaWindow.GetMonitorArea(hWnd);
          if (monitorArea2 != null)
          {
            MetaWindow.MINMAXINFO structure = (MetaWindow.MINMAXINFO) Marshal.PtrToStructure(lParam, typeof (MetaWindow.MINMAXINFO));
            structure.ptMaxPosition.x = monitorArea2.Offset.x;
            structure.ptMaxPosition.y = monitorArea2.Offset.y;
            structure.ptMaxSize.x = monitorArea2.Work.Width;
            structure.ptMaxSize.y = monitorArea2.Work.Height;
            structure.ptMinTrackSize.x = (int) window.MinWidth;
            structure.ptMinTrackSize.y = (int) window.MinHeight;
            Marshal.StructureToPtr<MetaWindow.MINMAXINFO>(structure, lParam, true);
            handled = true;
            break;
          }
          break;
        case 71:
          MetaWindow.WINDOWPOS structure1 = (MetaWindow.WINDOWPOS) Marshal.PtrToStructure(lParam, typeof (MetaWindow.WINDOWPOS));
          if (((int) structure1.flags & 2) != 2 && window.IsSnapped)
          {
            MetaWindow.MonitorArea monitorArea3 = MetaWindow.GetMonitorArea(hWnd);
            if (monitorArea3 != null)
              MetaWindow.UpdateResizeBorder((Window) window, monitorArea3, (double) structure1.x, (double) (structure1.x + structure1.cx));
            break;
          }
          break;
      }
      return IntPtr.Zero;
    }

    private static Window GetWindow(IntPtr hWnd) => HwndSource.FromHwnd(hWnd).RootVisual as Window;

    private static MetaWindow.MonitorArea GetMonitorArea(IntPtr hWnd)
    {
      IntPtr hMonitor = MetaWindow.MonitorFromWindow(hWnd, 2);
      if (!(hMonitor != IntPtr.Zero))
        return (MetaWindow.MonitorArea) null;
      MetaWindow.MONITORINFO lpmi = new MetaWindow.MONITORINFO();
      MetaWindow.GetMonitorInfo(hMonitor, lpmi);
      return new MetaWindow.MonitorArea(lpmi.rcMonitor, lpmi.rcWork);
    }

    private static void UpdateResizeBorder(
      Window window,
      MetaWindow.MonitorArea monitorArea,
      double left,
      double right)
    {
      double resizeBorderWidth = MetaWindow.GetResizeBorderWidth(window as MetaWindow);
      double virtualScreenLeft = SystemParameters.VirtualScreenLeft;
      double num = SystemParameters.VirtualScreenLeft + SystemParameters.VirtualScreenWidth;
      double left1 = left <= virtualScreenLeft + (double) monitorArea.Offset.x ? 0.0 : resizeBorderWidth;
      double right1 = right >= num ? 0.0 : resizeBorderWidth;
      MetaWindow.EnableResizeBorder(window, left1, 0.0, right1, 0.0);
    }

    private static void EnableResizeBorder(Window window)
    {
      double resizeBorderWidth = MetaWindow.GetResizeBorderWidth(window as MetaWindow);
      MetaWindow.EnableResizeBorder(window, resizeBorderWidth, resizeBorderWidth, resizeBorderWidth, resizeBorderWidth);
    }

    private static double GetResizeBorderWidth(MetaWindow window)
    {
      double num = (double) Math.Max(window.ResizeBorderWidth, window.DropShadowBlurRadius);
      return num > 6.0 ? num : 6.0;
    }

    private static void EnableResizeBorder(
      Window window,
      double left,
      double top,
      double right,
      double bottom)
    {
      WindowChrome windowChrome = WindowChrome.GetWindowChrome(window);
      Thickness thickness = new Thickness(left, top, right, bottom);
      windowChrome.ResizeBorderThickness = thickness;
      window.BorderThickness = thickness;
      WindowChrome.SetWindowChrome(window, windowChrome);
    }

    private static void DisableResizeBorder(Window window)
    {
      WindowChrome windowChrome = WindowChrome.GetWindowChrome(window);
      Thickness thickness = new Thickness(0.0);
      window.BorderThickness = thickness;
      windowChrome.ResizeBorderThickness = thickness;
      WindowChrome.SetWindowChrome(window, windowChrome);
    }

    private static void ShowDropShadow(MetaWindow window)
    {
      if (!(window.Effect is DropShadowEffect effect))
      {
        window.Effect = (Effect) MetaWindow.CreateDropShadowEffect(window.DropShadowColor, window.DropShadowOpacity, (double) window.DropShadowBlurRadius);
      }
      else
      {
        effect.Color = window.DropShadowColor;
        effect.Opacity = window.DropShadowOpacity;
        effect.BlurRadius = (double) Math.Max(window.DropShadowBlurRadius, 2);
      }
      if (window.ResizeMode == ResizeMode.NoResize || window.ResizeMode == ResizeMode.CanMinimize)
      {
        double resizeBorderWidth = MetaWindow.GetResizeBorderWidth(window);
        window.BorderThickness = new Thickness(resizeBorderWidth);
      }
      if (window.EnableDropShadow)
        return;
      MetaWindow.HideDropShadow(window);
    }

    private static void HideDropShadow(MetaWindow window)
    {
      if (!(window.Effect is DropShadowEffect effect))
        return;
      if (window.ResizeMode != ResizeMode.NoResize && window.ResizeMode != ResizeMode.CanMinimize)
      {
        effect.Opacity = 0.05;
        effect.BlurRadius = 10.0;
      }
      else
      {
        effect.Opacity = 0.0;
        effect.BlurRadius = 0.0;
      }
    }

    private static DropShadowEffect CreateDropShadowEffect(
      Color color,
      double opacity,
      double blurRadius)
    {
      return new DropShadowEffect()
      {
        Direction = 315.0,
        ShadowDepth = 0.0,
        RenderingBias = RenderingBias.Quality,
        Color = color,
        Opacity = opacity,
        BlurRadius = Math.Max(blurRadius, 2.0)
      };
    }

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs((UnmanagedType) 2)]
    private static extern bool GetCursorPos(out MetaWindow.POINT lpPoint);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    private void ShowSystemMenu(Window window, Point? point = null)
    {
      IntPtr handle = new WindowInteropHelper(window).Handle;
      IntPtr lParam;
      if (!point.HasValue)
      {
        MetaWindow.POINT lpPoint;
        MetaWindow.GetCursorPos(out lpPoint);
        lParam = new IntPtr((lpPoint.y << 16) + lpPoint.x + 1);
      }
      else
      {
        Point screen = this.PointToScreen(point.Value);
        lParam = new IntPtr(((int) screen.Y << 16) + (int) screen.X + 1);
      }
      MetaWindow.SendMessage(handle, 787, IntPtr.Zero, lParam);
    }

    private abstract class DependencyPropertyDefault
    {
      public const int ResizeBorderWidth = 6;
      public const bool EnableDropShadow = true;
      public const int DropShadowBlurRadius = 10;
      public const double DropShadowOpacity = 1.0;
      public const bool IsDragging = false;
    }

    private class MonitorArea
    {
      public MetaWindow.MonitorArea.Region Work;
      public MetaWindow.MonitorArea.Region Display;
      public MetaWindow.POINT Offset;

      public MonitorArea(MetaWindow.RECT display, MetaWindow.RECT work)
      {
        this.Display.Left = display.left;
        this.Display.Right = display.right;
        this.Display.Top = display.top;
        this.Display.Bottom = display.bottom;
        this.Display.Width = Math.Abs(display.right - display.left);
        this.Display.Height = Math.Abs(display.bottom - display.top);
        this.Work.Left = work.left;
        this.Work.Right = work.right;
        this.Work.Top = work.top;
        this.Work.Bottom = work.bottom;
        this.Work.Width = Math.Abs(work.right - work.left);
        this.Work.Height = Math.Abs(work.bottom - work.top);
        this.Offset = new MetaWindow.POINT(Math.Abs(work.left - display.left), Math.Abs(work.top - display.top));
      }

      public struct Region
      {
        public int Left;
        public int Right;
        public int Top;
        public int Bottom;
        public int Width;
        public int Height;
      }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Auto)]
    private class MONITORINFO
    {
      public int cbSize = Marshal.SizeOf(typeof (MetaWindow.MONITORINFO));
      public MetaWindow.RECT rcMonitor = new MetaWindow.RECT();
      public MetaWindow.RECT rcWork = new MetaWindow.RECT();
      public int dwFlags = 0;
    }

    private struct RECT
    {
      public int left;
      public int top;
      public int right;
      public int bottom;
    }

    private struct POINT
    {
      public int x;
      public int y;

      public POINT(int x, int y)
      {
        this.x = x;
        this.y = y;
      }
    }

    private struct MINMAXINFO
    {
      public MetaWindow.POINT ptReserved;
      public MetaWindow.POINT ptMaxSize;
      public MetaWindow.POINT ptMaxPosition;
      public MetaWindow.POINT ptMinTrackSize;
      public MetaWindow.POINT ptMaxTrackSize;
    }

    private struct WINDOWPOS
    {
      public IntPtr hwnd;
      public IntPtr hwndInsertAfter;
      public int x;
      public int y;
      public int cx;
      public int cy;
      public uint flags;
    }
  }
}
