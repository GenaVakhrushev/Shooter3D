using Shooter.Core;
using Shooter.Items.Core;

namespace Shooter.Items.Features.Pistol
{
    public class PistolController : Controller<PistolModel, PistolView>, IItemController
    {
        public void StartUseItem()
        {
            UnityEngine.Debug.Log("Start use pistol");
        }

        public void StopUseItem()
        {
            UnityEngine.Debug.Log("Stop use pistol");
        }
    }
}