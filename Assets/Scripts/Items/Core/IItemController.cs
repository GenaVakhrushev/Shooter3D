using Shooter.Core;

namespace Shooter.Items.Core
{
    public interface IItemController : IController
    {
        public void StartUseItem();
        public void StopUseItem();
    }
}