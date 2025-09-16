using Shooter.Core;
using UnityEngine;

namespace Shooter.HP
{
    public class HPController : Controller<HPModel, HPView>
    {
        public void AddHP(float amount)
        {
            SetHP(Model.CurrentHP + amount);
        }
        
        public void RemoveHP(float amount)
        {
            SetHP(Model.CurrentHP - amount);
        }

        private void SetHP(float value)
        {
            Model.CurrentHP = Mathf.Clamp(value, 0, Model.MaxHP);
            
            View.UpdateHPImage(Model.CurrentHP / Model.MaxHP);
        }
    }
}