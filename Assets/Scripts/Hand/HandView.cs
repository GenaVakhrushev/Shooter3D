using Shooter.Core;
using Shooter.Factories;
using Shooter.Items.Core;
using UnityEngine;
using Zenject;

namespace Shooter.Hand
{
    public class HandView : View
    {
        [SerializeField] private Transform itemParent;
        
        [Inject] private ItemsFactory itemsFactory;

        private ItemView currentItemView;
        
        public ItemView UpdateItemView(ItemModel itemModel)
        {
            if (currentItemView != null)
            {
                itemsFactory.ReturnView(currentItemView);
            }

            if (itemModel == null)
            {
                currentItemView = null;
                return null;
            }
            
            currentItemView = itemsFactory.GetItemView(itemModel);
            
            var viewTransform = currentItemView.transform;

            viewTransform.parent = itemParent;
            viewTransform.position = itemParent.position;
            viewTransform.rotation = itemParent.rotation;

            return currentItemView;
        }
    }
}