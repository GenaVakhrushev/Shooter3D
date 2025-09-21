using Shooter.Core;
using UnityEngine;

namespace Shooter.Items.Core
{
    public abstract class ItemView : View
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip useSound;
        
        private static readonly int Using = Animator.StringToHash("Using");

        public string ItemName { get; private set; }

        public void SetItemName(string itemName)
        {
            ItemName = itemName;
        }

        public void StartUseAnimation()
        {
            if (animator)
            {
                animator.SetBool(Using, true);
            }

            if (audioSource && useSound)
            {
                audioSource.PlayOneShot(useSound);
            }
        }

        public void StopUseAnimation()
        {
            if (animator)
            {
                animator.SetBool(Using, false);
            }
        }
    }
}