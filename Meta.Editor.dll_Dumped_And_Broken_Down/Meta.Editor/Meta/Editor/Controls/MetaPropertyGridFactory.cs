using Meta.Editor.Controls.CreationSuite;
using PropertyTools.Wpf;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

#nullable enable
namespace Meta.Editor.Controls
{
  public class MetaPropertyGridFactory : PropertyGridControlFactory
  {
    public virtual FrameworkElement CreateControl(
      PropertyItem pi,
      PropertyControlFactoryOptions options)
    {
      if (pi.GetAttribute<ImportantAttribute>() != null)
        return this.CreateAutoCompleteControl(pi, options);
      if (pi.GetAttribute<CrowdSignAttribute>() != null)
        return this.CreateAutoCompleteCrowdControl(pi, options);
      if (pi.GetAttribute<CountryAttribute>() != null)
        return this.CreateCountryScrollControl(pi, options);
      return pi.GetAttribute<MetaDirectorySelectAttribute>() != null ? this.CreateMetaDirectorySelectControl(pi) : base.CreateControl(pi, options);
    }

    protected virtual FrameworkElement CreateMetaDirectorySelectControl(PropertyItem property)
    {
      MetaDirectorySelect metaDirectorySelect = new MetaDirectorySelect();
      metaDirectorySelect.FolderBrowserDialogService = this.FolderBrowserDialogService;
      MetaDirectorySelect directorySelectControl = metaDirectorySelect;
      UpdateSourceTrigger updateSourceTrigger = property.AutoUpdateText ? UpdateSourceTrigger.PropertyChanged : UpdateSourceTrigger.Default;
      ((FrameworkElement) directorySelectControl).SetBinding(DirectoryPicker.DirectoryProperty, (BindingBase) property.CreateBinding(updateSourceTrigger, true));
      return (FrameworkElement) directorySelectControl;
    }

    protected virtual FrameworkElement CreateCountryScrollControl(
      PropertyItem pi,
      PropertyControlFactoryOptions options)
    {
      AutoFilteredComboBox filteredComboBox1 = new AutoFilteredComboBox();
      filteredComboBox1.Name = "WrestlerCountries";
      filteredComboBox1.SelectedValuePath = "index";
      filteredComboBox1.IsEditable = true;
      filteredComboBox1.IsDropDownOpen = false;
      filteredComboBox1.StaysOpenOnEdit = true;
      AutoFilteredComboBox filteredComboBox2 = filteredComboBox1;
      DataTemplate dataTemplate1 = new DataTemplate();
      dataTemplate1.VisualTree = new FrameworkElementFactory(typeof (StackPanel));
      DataTemplate dataTemplate2 = dataTemplate1;
      filteredComboBox2.ItemTemplate = dataTemplate2;
      filteredComboBox1.ItemsPanel = new ItemsPanelTemplate(new FrameworkElementFactory(typeof (VirtualizingStackPanel)));
      AutoFilteredComboBox element = filteredComboBox1;
      if (pi.ItemsSourceDescriptor != null)
        element.SetBinding(ItemsControl.ItemsSourceProperty, (BindingBase) new Binding(pi.ItemsSourceDescriptor.Name));
      element.SetBinding(Selector.SelectedItemProperty, (BindingBase) pi.CreateBinding(UpdateSourceTrigger.Default, true));
      MultiBinding binding1 = new MultiBinding();
      binding1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
      binding1.StringFormat = "{0} {1} {2}";
      Binding binding2 = new Binding("country");
      Binding binding3 = new Binding("state");
      Binding binding4 = new Binding("city");
      binding1.Bindings.Add((BindingBase) binding2);
      binding1.Bindings.Add((BindingBase) binding3);
      binding1.Bindings.Add((BindingBase) binding4);
      FrameworkElementFactory child = new FrameworkElementFactory(typeof (TextBlock));
      child.SetBinding(TextBlock.TextProperty, (BindingBase) binding1);
      child.SetValue(TextBlock.FontWeightProperty, (object) FontWeights.Bold);
      element.ItemTemplate.VisualTree.AppendChild(child);
      Grid countryScrollControl = new Grid();
      countryScrollControl.ColumnDefinitions.Add(new ColumnDefinition()
      {
        Width = new GridLength(1.0, GridUnitType.Star)
      });
      countryScrollControl.ColumnDefinitions.Add(new ColumnDefinition()
      {
        Width = new GridLength(1.0, GridUnitType.Auto)
      });
      countryScrollControl.Children.Add((UIElement) element);
      return (FrameworkElement) countryScrollControl;
    }

    protected virtual FrameworkElement CreateAutoCompleteCrowdControl(
      PropertyItem pi,
      PropertyControlFactoryOptions options)
    {
      AutoFilteredComboBox filteredComboBox1 = new AutoFilteredComboBox();
      filteredComboBox1.IsEditable = true;
      filteredComboBox1.IsDropDownOpen = false;
      filteredComboBox1.StaysOpenOnEdit = true;
      AutoFilteredComboBox filteredComboBox2 = filteredComboBox1;
      DataTemplate dataTemplate1 = new DataTemplate();
      dataTemplate1.VisualTree = new FrameworkElementFactory(typeof (VirtualizingStackPanel));
      DataTemplate dataTemplate2 = dataTemplate1;
      filteredComboBox2.ItemTemplate = dataTemplate2;
      filteredComboBox1.ItemsPanel = new ItemsPanelTemplate(new FrameworkElementFactory(typeof (VirtualizingStackPanel)));
      AutoFilteredComboBox element = filteredComboBox1;
      if (pi.ItemsSourceDescriptor != null)
        element.SetBinding(ItemsControl.ItemsSourceProperty, (BindingBase) new Binding(pi.ItemsSourceDescriptor.Name)
        {
          Converter = (IValueConverter) new ItemsSourceConverter()
        });
      element.SetBinding(Selector.SelectedItemProperty, (BindingBase) pi.CreateBinding(UpdateSourceTrigger.Default, true));
      MultiBinding binding1 = new MultiBinding();
      binding1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
      binding1.StringFormat = "{0} {1}";
      Binding binding2 = new Binding("Id");
      Binding binding3 = new Binding("Name");
      binding1.Bindings.Add((BindingBase) binding2);
      binding1.Bindings.Add((BindingBase) binding3);
      FrameworkElementFactory child = new FrameworkElementFactory(typeof (TextBlock));
      child.SetBinding(TextBlock.TextProperty, (BindingBase) binding1);
      child.SetValue(TextBlock.FontWeightProperty, (object) FontWeights.Bold);
      element.ItemTemplate.VisualTree.AppendChild(child);
      Grid completeCrowdControl = new Grid();
      completeCrowdControl.Children.Add((UIElement) element);
      return (FrameworkElement) completeCrowdControl;
    }

    protected virtual FrameworkElement CreateAutoCompleteControl(
      PropertyItem pi,
      PropertyControlFactoryOptions options)
    {
      AutoFilteredComboBox filteredComboBox1 = new AutoFilteredComboBox();
      filteredComboBox1.IsEditable = true;
      filteredComboBox1.IsDropDownOpen = false;
      filteredComboBox1.StaysOpenOnEdit = true;
      filteredComboBox1.IsSynchronizedWithCurrentItem = new bool?(false);
      AutoFilteredComboBox filteredComboBox2 = filteredComboBox1;
      DataTemplate dataTemplate1 = new DataTemplate();
      dataTemplate1.VisualTree = new FrameworkElementFactory(typeof (VirtualizingStackPanel));
      DataTemplate dataTemplate2 = dataTemplate1;
      filteredComboBox2.ItemTemplate = dataTemplate2;
      filteredComboBox1.ItemsPanel = new ItemsPanelTemplate(new FrameworkElementFactory(typeof (VirtualizingStackPanel)));
      AutoFilteredComboBox s1 = filteredComboBox1;
      if (pi.ItemsSourceDescriptor != null)
        s1.SetBinding(ItemsControl.ItemsSourceProperty, (BindingBase) new Binding(pi.ItemsSourceDescriptor.Name)
        {
          Converter = (IValueConverter) new ItemsSourceConverter()
        });
      s1.SetBinding(Selector.SelectedItemProperty, (BindingBase) pi.CreateBinding(UpdateSourceTrigger.PropertyChanged, true));
      s1.Loaded += (RoutedEventHandler) ((sender, e) =>
      {
        DefaultIndexAttribute defaultSelectedItemIndexAttribute = pi.GetAttribute<DefaultIndexAttribute>();
        if (defaultSelectedItemIndexAttribute == null)
          return;
        s1.SelectedValue = (object) s1.ItemsSource.Cast<JObject>().FirstOrDefault<JObject>((Func<JObject, bool>) (s => s.Name.Equals(defaultSelectedItemIndexAttribute.DefaultSelectedIndex)));
      });
      FrameworkElementFactory child = new FrameworkElementFactory(typeof (TextBlock));
      child.SetBinding(TextBlock.TextProperty, (BindingBase) new Binding("Name"));
      child.SetValue(TextBlock.FontWeightProperty, (object) FontWeights.Bold);
      s1.ItemTemplate.VisualTree.AppendChild(child);
      Grid autoCompleteControl = new Grid();
      autoCompleteControl.Children.Add((UIElement) s1);
      return (FrameworkElement) autoCompleteControl;
    }
  }
}
