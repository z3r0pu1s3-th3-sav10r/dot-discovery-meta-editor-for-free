using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

#nullable enable
namespace Meta.Editor.Controls
{
  public class AutoFilteredComboBox : ComboBox
  {
    private int _silenceEvents;
    private ICollectionView _collView;
    private string _savedText;
    private bool _textSaved;
    private int _start;
    private int _length;
    private bool _keyboardSelectionGuard;
    public static readonly DependencyProperty IsCaseSensitiveProperty = DependencyProperty.Register(nameof (IsCaseSensitive), typeof (bool), typeof (AutoFilteredComboBox), (PropertyMetadata) new UIPropertyMetadata((object) false));
    public static readonly DependencyProperty DropDownOnFocusProperty = DependencyProperty.Register(nameof (DropDownOnFocus), typeof (bool), typeof (AutoFilteredComboBox), (PropertyMetadata) new UIPropertyMetadata((object) true));
    private TextBox _editableTextBoxSite;

    public AutoFilteredComboBox()
    {
      ((PropertyDescriptor) DependencyPropertyDescriptor.FromProperty(ComboBox.TextProperty, typeof (AutoFilteredComboBox))).AddValueChanged((object) this, new EventHandler(this.OnTextChanged));
      this.RegisterIsCaseSensitiveChangeNotification();
    }

    [Description("The way the combo box treats the case sensitivity of typed text")]
    [Category("AutoFiltered ComboBox")]
    [DefaultValue(true)]
    public bool IsCaseSensitive
    {
      [DebuggerStepThrough] get
      {
        return (bool) this.GetValue(AutoFilteredComboBox.IsCaseSensitiveProperty);
      }
      [DebuggerStepThrough] set
      {
        this.SetValue(AutoFilteredComboBox.IsCaseSensitiveProperty, (object) value);
      }
    }

    protected virtual void OnIsCaseSensitiveChanged(object sender, EventArgs e)
    {
      if (this.IsCaseSensitive)
        this.IsTextSearchEnabled = false;
      this.RefreshFilter();
    }

    private void RegisterIsCaseSensitiveChangeNotification()
    {
      ((PropertyDescriptor) DependencyPropertyDescriptor.FromProperty(AutoFilteredComboBox.IsCaseSensitiveProperty, typeof (AutoFilteredComboBox))).AddValueChanged((object) this, new EventHandler(this.OnIsCaseSensitiveChanged));
    }

    [Description("The way the combo box behaves when it receives focus")]
    [Category("AutoFiltered ComboBox")]
    [DefaultValue(true)]
    public bool DropDownOnFocus
    {
      [DebuggerStepThrough] get
      {
        return (bool) this.GetValue(AutoFilteredComboBox.DropDownOnFocusProperty);
      }
      [DebuggerStepThrough] set
      {
        this.SetValue(AutoFilteredComboBox.DropDownOnFocusProperty, (object) value);
      }
    }

    public TextBox EditableTextBox
    {
      get => this._editableTextBoxSite;
      set => this._editableTextBoxSite = value;
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.EditableTextBox = this.Template.FindName("PART_EditableTextBox", (FrameworkElement) this) as TextBox;
      this.EditableTextBox.SelectionChanged += new RoutedEventHandler(this.EditableTextBox_SelectionChanged);
      if (this.ItemsPopup == null)
        return;
      this.ItemsPopup.Focusable = true;
    }

    private Popup ItemsPopup => (Popup) this.GetTemplateChild("PART_Popup");

    private ScrollViewer ItemsScrollViewer
    {
      get
      {
        return !(this.ItemsPopup.FindName("DropDownBorder") is Border name) ? (ScrollViewer) null : name.Child as ScrollViewer;
      }
    }

    private void EditableTextBox_SelectionChanged(object sender, RoutedEventArgs e)
    {
      TextBox originalSource = (TextBox) e.OriginalSource;
      int selectionStart = originalSource.SelectionStart;
      int selectionLength = originalSource.SelectionLength;
      if (this._silenceEvents > 0)
        return;
      this._start = selectionStart;
      this._length = selectionLength;
      this.RefreshFilter();
      this.ScrollItemsToTop();
    }

    private void RestoreSavedText()
    {
      this.Text = this._textSaved ? this._savedText : "";
      if (this.EditableTextBox == null)
        return;
      this.EditableTextBox.SelectAll();
    }

    private void ClearFilter()
    {
      this._length = 0;
      this._start = 0;
      this.RefreshFilter();
      this.Text = "";
      this.ScrollItemsToTop();
    }

    private void SilenceEvents() => ++this._silenceEvents;

    private void UnSilenceEvents()
    {
      if (this._silenceEvents <= 0)
        return;
      --this._silenceEvents;
    }

    protected override void OnGotFocus(RoutedEventArgs e)
    {
      base.OnGotFocus(e);
      if (this.ItemsSource == null || !this.DropDownOnFocus)
        return;
      this.IsDropDownOpen = true;
    }

    protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
    {
      if (this.Text.Length == 0)
        this.RestoreSavedText();
      else if (this.SelectedItem != null)
        this._savedText = this.SelectedItem.ToString();
      base.OnPreviewLostKeyboardFocus(e);
    }

    private void ScrollItemsToTop() => this.ItemsScrollViewer?.ScrollToTop();

    private void RefreshFilter()
    {
      if (this.ItemsSource == null)
        return;
      using (this.Items.DeferRefresh())
        this.Items.Filter = new Predicate<object>(this.FilterPredicate);
    }

    private bool FilterPredicate(object value)
    {
      if (value == null)
        return false;
      if (this.Text.Length == 0)
        return true;
      string str = this.Text;
      if (this._length > 0 && this._start + this._length == this.Text.Length)
        str = str.Substring(0, this._start);
      return value.ToString().IndexOf(str, StringComparison.InvariantCultureIgnoreCase) >= 0;
    }

    protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
    {
      // ISSUE: unable to decompile the method.
    }

    protected override void OnInitialized(EventArgs e) => base.OnInitialized(e);

    private void OnTextChanged(object sender, EventArgs e)
    {
      if (!this._textSaved)
      {
        this._savedText = this.Text;
        this._textSaved = true;
      }
      if (this.IsTextSearchEnabled || this._silenceEvents != 0)
        return;
      this.RefreshFilter();
      if (this.Text.Length <= 0)
        return;
      int length1 = this.Text.Length;
      this._collView = CollectionViewSource.GetDefaultView((object) this.ItemsSource);
      IEnumerator enumerator = ((IEnumerable) this._collView).GetEnumerator();
      try
      {
        if (!enumerator.MoveNext())
          return;
        object current = enumerator.Current;
        int length2 = current.ToString().Length;
        this.SelectedItem = current;
        this.SilenceEvents();
        this.EditableTextBox.Text = current.ToString();
        this.EditableTextBox.Select(length1, length2 - length1);
        this.UnSilenceEvents();
      }
      finally
      {
        if (enumerator is IDisposable disposable)
          disposable.Dispose();
      }
    }

    protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
    {
      base.OnItemsChanged(e);
    }

    protected override void OnPreviewKeyDown(KeyEventArgs e)
    {
      Key key = e.Key;
      if (key <= 6)
      {
        if (key == 3 || key == 6)
          ;
      }
      else if (key != 13)
      {
        if ((key == 24 || key == 26) && !this._keyboardSelectionGuard)
        {
          this._keyboardSelectionGuard = true;
          this.SilenceEvents();
        }
      }
      else
      {
        this._keyboardSelectionGuard = false;
        this.UnSilenceEvents();
        this.ClearFilter();
        return;
      }
      base.OnPreviewKeyDown(e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      if (e.Key == 13)
      {
        this._keyboardSelectionGuard = false;
        this.UnSilenceEvents();
        this.ClearFilter();
      }
      else
        base.OnKeyDown(e);
    }
  }
}
