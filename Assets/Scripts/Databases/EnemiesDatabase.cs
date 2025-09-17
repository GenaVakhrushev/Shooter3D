using Shooter.Enemies;
using Shooter.Enemies.Core;
using UnityEngine;

namespace Shooter.Databases
{
    [CreateAssetMenu(fileName = nameof(EnemiesDatabase), menuName = "Databases/" + nameof(EnemiesDatabase), order = 0)]
    public class EnemiesDatabase : Database<EnemyConfig> { }
}