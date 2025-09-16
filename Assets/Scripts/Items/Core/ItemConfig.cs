using UnityEngine;

namespace Shooter.Items.Core
{
    [CreateAssetMenu(fileName = nameof(ItemConfig), menuName = "Configs/" + nameof(ItemConfig), order = 0)]
    public class ItemConfig : ScriptableObject
    {
        [SerializeReference] 
        public ItemModel ItemModel;
        public ItemView ItemView;
    }
}