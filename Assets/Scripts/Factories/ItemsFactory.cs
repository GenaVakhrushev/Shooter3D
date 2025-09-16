using Shooter.Databases;
using Shooter.Items.Core;

namespace Shooter.Factories
{
    public class ItemsFactory : ViewsFactory
    {
        public ItemsFactory(ItemsDatabase itemsDatabase)
        {
            foreach (var itemConfig in itemsDatabase.ItemConfigs)
            {
                AddViewPrefab(itemConfig.ItemModel.Name, itemConfig.ItemView);
            }
        }

        public ItemView GetItemView(ItemModel itemModel)
        {
            var itemView = (ItemView)GetView(itemModel.Name);
            
            itemView.ItemName = itemModel.Name;
            
            return itemView;
        }

        public void ReturnView(ItemView itemView) => ReturnView(itemView.ItemName, itemView);
    }
}