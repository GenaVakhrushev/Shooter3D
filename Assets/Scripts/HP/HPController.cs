using System;
using Shooter.Core;
using UnityEngine;

namespace Shooter.HP
{
    public class HPController : Controller<HPModel, HPView>
    {
        public event Action LostHP;
        
        protected override void OnViewChanged()
        {
            UpdateView();
        }

        protected override void OnModelChanged()
        {
            UpdateView();
        }

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
            var hp = Mathf.Clamp(value, 0, Model.MaxHP);
            Model.CurrentHP = hp;

            if (hp == 0)
            {
                LostHP?.Invoke();
            }

            UpdateView();
        }

        private void UpdateView()
        {
            if (View != null && Model != null)
            {
                View.UpdateHPInfo(Model.CurrentHP, Model.MaxHP);
            }
        }
    }
}