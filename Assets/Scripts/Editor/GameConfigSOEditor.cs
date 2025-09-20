using System.IO;
using Shooter.GameManagement;
using Shooter.Utils;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GameConfigSO))]
    public class GameConfigSOEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var configSO = (GameConfigSO)target;

            if (GUILayout.Button("Generate JSON"))
            {
                var path = EditorUtility.SaveFilePanel("Save Game config", Application.dataPath, "Game config", "json");

                if (path.Length > 0)
                {
                    var gameConfig = configSO.CreateGameConfig();
                    
                    File.WriteAllText(path, Utilities.ToJson(gameConfig));
                }
            }
        }
    }
}