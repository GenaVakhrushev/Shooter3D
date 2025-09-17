using UnityEngine;

namespace Shooter.Databases
{
    public class Database<T> : ScriptableObject where T : ScriptableObject
    {
        public T[] Configs;
    }
}