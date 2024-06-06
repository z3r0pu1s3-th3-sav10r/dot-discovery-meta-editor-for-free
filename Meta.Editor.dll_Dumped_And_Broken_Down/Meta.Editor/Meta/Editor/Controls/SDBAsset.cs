using System.ComponentModel;

#nullable enable
namespace Meta.Editor.Controls
{
  public class SDBAsset : INotifyPropertyChanged
  {
    private uint id;

    public uint Index { get; set; }

    public uint Id
    {
      get => this.id;
      set
      {
        if ((int) this.id == (int) value)
          return;
        this.id = value;
        this.OnPropertyChanged(nameof (Id));
      }
    }

    public string String { get; set; }

    public uint Address { get; set; }

    public uint Size { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
