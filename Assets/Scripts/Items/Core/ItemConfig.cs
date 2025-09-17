using UnityEngine;

namespace Shooter.Items.Core
{
    public abstract class ItemConfig : ScriptableObject
    {
        public string ItemName;
        public ItemView ItemView;

        public abstract ItemModel CreateModel();
    }
}