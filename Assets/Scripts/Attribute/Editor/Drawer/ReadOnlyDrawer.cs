using UnityEditor;
using UnityEngine;

namespace Attribute.Editor.Drawer
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // 保存当前 GUI 的启用状态
            // GUI.enabled = false;
            // 绘制属性
            EditorGUI.PropertyField(position, property, label, true);
            // 恢复 GUI 的启用状态
            // GUI.enabled = true;
        }
    }
}