using Shooter.Core;
using Shooter.Items.Core;

namespace Shooter.Hand
{
    public class HandModel : IModel
    {
        public ItemModel HeldItemModel;

        public object Clone() => new HandModel { HeldItemModel = HeldItemModel };
    }
}