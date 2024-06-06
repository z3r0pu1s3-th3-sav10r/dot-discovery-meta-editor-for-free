using System;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  public class Location
  {
    public string country { get; set; }

    public string state { get; set; }

    public string city { get; set; }

    public int? city_group { get; set; }

    public int? country_group { get; set; }

    public Decimal callname { get; set; }

    public int index { get; set; }

    public override string ToString()
    {
      return string.Format("{0} {1} {2}", (object) this.country, (object) this.state, (object) this.city);
    }
  }
}
