using System;
using Editor.EditorUtils;
using Shooter.Items.Core;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ItemConfig))]
    public class ItemConfigEditor : UnityEditor.Editor
    {
        protected const string ITEM_MODEL_PROPERTY_NAME = "ItemModel";
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            var itemModelProperty = serializedObject.FindProperty(ITEM_MODEL_PROPERTY_NAME);
            var itemModelType = typeof(ItemModel);
            GUIFunctions.TypeSelector("Select item model", itemModelType, type => SetItemModel(itemModelProperty, type));
            
            var itemModel = itemModelProperty.managedReferenceValue;
            if (itemModel != null)
            {
                EditorGUILayout.PropertyField(itemModelProperty, new GUIContent(itemModel.GetType().Name), true);
            }
            else
            {
                EditorGUILayout.HelpBox("Item model is null. Select item model", MessageType.Error);
            }
            
            DrawPropertiesExcluding(serializedObject, ITEM_MODEL_PROPERTY_NAME, "m_Script");
            
            serializedObject.ApplyModifiedProperties();
        }
        
        private void SetItemModel(SerializedProperty itemModelProperty, Type itemModelType)
        {
            var itemModel = Activator.CreateInstance(itemModelType);

            itemModelProperty.managedReferenceValue = itemModel;

            serializedObject.ApplyModifiedProperties();
        }
    }
}