using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace Shooter.Utils
{
    public static class EventSystemUtility
    {

        private static InputSystemUIInputModule module;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Init()
        {
            module = null;
        }

        public static bool IsPointerOverGUIAction()
        {
            if (!EventSystem.current)
            {
                return false;
            }

            if (!module)
            {
                module = (InputSystemUIInputModule)EventSystem.current.currentInputModule;
            }

            return module.GetLastRaycastResult(Pointer.current.deviceId).isValid;
        }
    }
}