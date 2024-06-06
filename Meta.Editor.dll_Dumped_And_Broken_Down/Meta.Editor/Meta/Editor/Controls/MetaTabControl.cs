using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

#nullable enable
namespace Meta.Editor.Controls
{
  [TemplatePart(Name = "PART_ScrollLeft", Type = typeof (RepeatButton))]
  [TemplatePart(Name = "PART_ScrollRight", Type = typeof (RepeatButton))]
  [TemplatePart(Name = "PART_ScrollViewer", Type = typeof (ScrollViewer))]
  public class MetaTabControl : TabControl
  {
    private const string PART_ScrollLeft = "PART_ScrollLeft";
    private const string PART_ScrollRight = "PART_ScrollRight";
    private const string PART_ScrollViewer = "PART_ScrollViewer";
    private RepeatButton? scrollLeftButton;
    private RepeatButton? scrollRightButton;
    private ScrollViewer? scrollViewer;

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.scrollLeftButton = this.GetTemplateChild("PART_ScrollLeft") as RepeatButton;
      this.scrollLeftButton.Click += new RoutedEventHandler(this.ScrollLeftButton_Click);
      this.scrollRightButton = this.GetTemplateChild("PART_ScrollRight") as RepeatButton;
      this.scrollRightButton.Click += new RoutedEventHandler(this.ScrollRightButton_Click);
      this.scrollViewer = this.GetTemplateChild("PART_ScrollViewer") as ScrollViewer;
      this.scrollViewer.Loaded += (RoutedEventHandler) ((s, e) => this.UpdateControls());
      this.scrollViewer.ScrollChanged += (ScrollChangedEventHandler) ((s, e) => this.UpdateControls());
      this.SelectionChanged += (SelectionChangedEventHandler) ((s, e) => this.ScrollToSelectedItem());
    }

    private void ScrollLeftButton_Click(object sender, RoutedEventArgs e)
    {
      this.ScrollToItem(this.GetItemByOffset(Math.Max(this.scrollViewer.HorizontalOffset, 0.0)));
    }

    private void ScrollRightButton_Click(object sender, RoutedEventArgs e)
    {
      this.ScrollToItem(this.GetItemByOffset(Math.Min(this.scrollViewer.HorizontalOffset + this.scrollViewer.ViewportWidth + 1.0, this.scrollViewer.ExtentWidth)));
    }

    private void UpdateControls()
    {
      double num1 = Math.Max(this.scrollViewer.HorizontalOffset, 0.0);
      double num2 = Math.Max(this.scrollViewer.ScrollableWidth, 0.0);
      this.scrollLeftButton.Visibility = num2 == 0.0 ? Visibility.Collapsed : Visibility.Visible;
      this.scrollRightButton.Visibility = num2 == 0.0 ? Visibility.Collapsed : Visibility.Visible;
      this.scrollLeftButton.IsEnabled = num1 > 0.0;
      this.scrollRightButton.IsEnabled = num1 < num2;
    }

    private void ScrollToSelectedItem()
    {
      if (!(this.SelectedItem is TabItem selectedItem))
        return;
      if (selectedItem.ActualWidth == 0.0 && !selectedItem.IsLoaded)
        selectedItem.Loaded += (RoutedEventHandler) ((s, e) => this.ScrollToSelectedItem());
      else
        this.ScrollToItem(selectedItem);
    }

    private void ScrollToItem(TabItem ti)
    {
      double offset = 0.0;
      foreach (TabItem tabItem in (IEnumerable) this.Items)
      {
        if (tabItem != ti)
          offset += tabItem.ActualWidth;
        else
          break;
      }
      if (offset + ti.ActualWidth > this.scrollViewer.HorizontalOffset + this.scrollViewer.ViewportWidth)
      {
        this.scrollViewer.ScrollToHorizontalOffset(offset + ti.ActualWidth - this.scrollViewer.ViewportWidth);
      }
      else
      {
        if (offset >= this.scrollViewer.HorizontalOffset)
          return;
        this.scrollViewer.ScrollToHorizontalOffset(offset);
      }
    }

    private TabItem GetItemByOffset(double offset)
    {
      double num = 0.0;
      foreach (TabItem itemByOffset in (IEnumerable) this.Items)
      {
        if (num + itemByOffset.ActualWidth >= offset)
          return itemByOffset;
        num += itemByOffset.ActualWidth;
      }
      return this.Items[this.Items.Count - 1] as TabItem;
    }
  }
}
