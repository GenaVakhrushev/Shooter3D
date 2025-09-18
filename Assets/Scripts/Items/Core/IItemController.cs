using Shooter.Core;

namespace Shooter.Items.Core
{
    public interface IItemController : IController
    {
        public void StartUseItem(object user);
        public void StopUseItem(object user);
    }
}