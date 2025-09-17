using Shooter.Databases;
using Shooter.Items.Core;

namespace Shooter.Factories
{
    public class ItemsFactory : ViewsFactory
    {
        public ItemsFactory(ItemsDatabase itemsDatabase)
        {
            foreach (var itemConfig in itemsDatabase.Configs)
            {
                AddViewPrefab(itemConfig.ItemName, itemConfig.ItemView);
            }
        }

        public ItemView GetItemView(ItemModel itemModel)
        {
            var itemView = (ItemView)GetView(itemModel.Name);
            
            itemView.SetItemName(itemModel.Name);
            
            return itemView;
        }

        public void ReturnView(ItemView itemView) => ReturnView(itemView.ItemName, itemView);
    }
}