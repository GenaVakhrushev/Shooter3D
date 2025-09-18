using UnityEngine;

namespace Shooter.UI
{
    public abstract class Screen : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            OnHide();
        }
        
        protected virtual void OnShow(){}
        protected virtual void OnHide(){}
    }
}