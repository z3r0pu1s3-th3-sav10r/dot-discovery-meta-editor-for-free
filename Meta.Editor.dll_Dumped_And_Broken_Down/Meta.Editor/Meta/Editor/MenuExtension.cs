using Meta.Editor.Commands;

#nullable enable
namespace Meta.Editor
{
    public abstract class MenuExtension
    {
        public virtual string TopLevelMenuName { get; }

        public virtual string SubLevelMenuName { get; }

        public virtual string MenuItemName { get; }

        public virtual string Icon { get; }

        public virtual RelayCommand MenuItemClicked { get; }
    }
}
