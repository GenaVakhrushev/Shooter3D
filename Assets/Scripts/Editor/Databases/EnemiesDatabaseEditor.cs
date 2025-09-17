using Shooter.Databases;
using Shooter.Enemies;
using Shooter.Enemies.Core;
using UnityEditor;

namespace Editor.Databases
{
    [CustomEditor(typeof(EnemiesDatabase))]
    public class EnemiesDatabaseEditor : DatabaseEditor<EnemyConfig>
    {
        
    }
}