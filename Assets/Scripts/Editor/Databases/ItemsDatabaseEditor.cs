using Shooter.Databases;
using Shooter.Items.Core;
using UnityEditor;

namespace Editor.Databases
{
    [CustomEditor(typeof(ItemsDatabase))]
    public class ItemsDatabaseEditor : DatabaseEditor<ItemConfig>
    {
        
    }
}