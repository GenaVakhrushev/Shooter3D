using Shooter.Core;
using Shooter.Items.Core;
using Shooter.Services;

namespace Shooter.Hand
{
    public class HandController : Controller<HandModel, HandView>
    {
        private readonly ItemsService itemsService;
        private readonly object user;

        private IItemController itemController;

        public HandController(ItemsService itemsService, object user)
        {
            this.itemsService = itemsService;
            this.user = user;
        }

        public void TakeItem(ItemModel itemModel)
        {
            Model.HeldItemModel = itemModel;

            if (itemModel != null)
            {
                itemController = itemsService.GetController(itemModel.GetControllerType());
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

        public void StartUseItem() => itemController?.StartUseItem(user);

        public void StopUseItem() => itemController?.StopUseItem(user);
    }
}