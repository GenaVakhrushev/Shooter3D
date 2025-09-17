using Shooter.Items.Core;
using UnityEngine;

namespace Shooter.Databases
{
    [CreateAssetMenu(fileName = nameof(ItemsDatabase), menuName = "Databases/" + nameof(ItemsDatabase), order = 0)]
    public class ItemsDatabase : Database<ItemConfig> { }
}