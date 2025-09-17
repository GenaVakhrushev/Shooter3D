using Shooter.Core;

namespace Shooter.Items.Core
{
    public abstract class ItemView : View
    {
        public string ItemName { get; private set; }

        public void SetItemName(string itemName)
        {
            ItemName = itemName;
        }
    }
}