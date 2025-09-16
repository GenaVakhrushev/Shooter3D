using System;
using Shooter.Core;
using Shooter.Items.Core;

namespace Shooter.Hand
{
    public class HandController : Controller<HandModel, HandView>
    {
        private IItemController itemController;

        public void TakeItem(ItemModel itemModel)
        {
            Model.HeldItemModel = itemModel;

            if (itemModel != null)
            {
                itemController = (IItemController)Activator.CreateInstance(itemModel.GetControllerType());
                itemController.SetModel(itemModel);
                
                if (View != null)
                {
                    var itemView = View.UpdateItemView(itemModel);
                    itemController.SetView(itemView);
                }
            }
            else
            {
                itemController = null;
            }
        }

        public void DropItem()
        {
            TakeItem(null);
        }

        public void StartUseItem() => itemController?.StartUseItem();

        public void StopUseItem() => itemController?.StopUseItem();
    }
}