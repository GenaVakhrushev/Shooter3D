using System.Linq;
using Shooter.Databases;
using UnityEditor;
using UnityEngine;

namespace Editor.Databases
{
    public abstract class DatabaseEditor<T> : UnityEditor.Editor where T : ScriptableObject
    {
        public override void OnInspectorGUI()
        {
            var configName = typeof(T).Name;
            
            if (GUILayout.Button($"Find {configName}s"))
            {
                var guids = AssetDatabase.FindAssets($"t:{configName}");
                var configs = guids
                    .Select(AssetDatabase.GUIDToAssetPath)
                    .Select(AssetDatabase.LoadAssetAtPath<T>)
                    .ToArray();

                var database = (Database<T>)target;
                var configsProperty = serializedObject.FindProperty(nameof(database.Configs));

                configsProperty.arraySize = configs.Length;
                for (var i = 0; i < configs.Length; i++)
                {
                    configsProperty.GetArrayElementAtIndex(i).objectReferenceValue = configs[i];
                }

                serializedObject.ApplyModifiedProperties();
            }
            
            base.OnInspectorGUI();
        }
    }
}