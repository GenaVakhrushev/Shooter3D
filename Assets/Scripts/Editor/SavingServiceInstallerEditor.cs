using Shooter.Installers;
using Shooter.Services;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(SavingServiceInstaller))]
    public class SavingServiceInstallerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Clear save"))
            {
                SavingService.ClearSave();
            }
        }
    }
}