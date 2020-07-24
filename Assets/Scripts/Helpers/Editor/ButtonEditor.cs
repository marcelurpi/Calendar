using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CanEditMultipleObjects]
[CustomEditor(typeof(UnityEngine.Object), true)]
public class ButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MethodInfo[] methods = target.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        methods = methods.Where(m => m.GetParameters().Length == 0).ToArray();

        bool anyButton = false;
        foreach (MethodInfo method in methods)
        {
            ButtonAttribute button = (ButtonAttribute)Attribute.GetCustomAttribute(method, typeof(ButtonAttribute));
            if (button != null)
            {
                anyButton = true;
                break;
            }
        }

        if(anyButton) GUILayout.Space(10);

        foreach (MethodInfo method in methods)
        {
            ButtonAttribute button = (ButtonAttribute)Attribute.GetCustomAttribute(method, typeof(ButtonAttribute));

            if (button == null) continue;

            ButtonMode buttonMode = button.GetButtonMode();

            bool buttonActive = false;
            if (buttonMode == ButtonMode.ActiveAlways) buttonActive = true;
            else if (buttonMode == ButtonMode.ActiveOnEditMode && !Application.isPlaying) buttonActive = true;
            else if (buttonMode == ButtonMode.ActiveOnPlayMode && Application.isPlaying) buttonActive = true;

            bool wasEnabled = GUI.enabled;
            if (buttonActive == false) GUI.enabled = false;

            if (GUILayout.Button(button.GetName()))
            {
                foreach (UnityEngine.Object t in targets)
                {
                    method.Invoke(t, null);
                }
            }

            GUI.enabled = wasEnabled;
        }
    }
}
