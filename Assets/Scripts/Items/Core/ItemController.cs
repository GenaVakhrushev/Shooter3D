using Shooter.Core;

namespace Shooter.Items.Core
{
    public abstract class ItemController<TItemModel, TItemView> : Controller<TItemModel, TItemView>, IItemController
        where TItemModel : ItemModel
        where TItemView : ItemView
    {
        public virtual void StartUseItem(object user)
        {
            View.StartUseAnimation();
        }

        public virtual void StopUseItem(object user)
        {
            View.StopUseAnimation();
        }
    }
}