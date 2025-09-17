using Shooter.Utils;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Editor
{
    [CustomEditor(typeof(SceneContextExtensions))]
    public class SceneContextExtensionsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Update installers"))
            {
                var sceneContext = ((SceneContextExtensions)target).GetComponent<SceneContext>();
                
                Undo.RecordObject(sceneContext, "Update installers");

                sceneContext.Installers = sceneContext.GetComponentsInChildren<MonoInstaller>();
            }
        }
    }
}