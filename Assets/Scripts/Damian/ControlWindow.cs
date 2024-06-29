using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class ControlWindow : EditorWindow
{
    private ControlPanel controlPanel;

    [MenuItem("Artist proof stuff/Control Window")]
    private static void ShowWindow()
    {
        var window = GetWindow<ControlWindow>();
        window.titleContent = new GUIContent("Control Window");
        window.Show();
    }

    private void OnEnable()
    {
        // Load the ControlPanel ScriptableObject or create one if it doesn't exist
        controlPanel = AssetDatabase.LoadAssetAtPath<ControlPanel>("Assets/Scripts/Damian/ControlPanel.asset");
        if (controlPanel == null)
        {
            controlPanel = CreateInstance<ControlPanel>();
            AssetDatabase.CreateAsset(controlPanel, "Assets/ControlPanel.asset");
            AssetDatabase.SaveAssets();
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Control Panel", EditorStyles.boldLabel);

        SerializedObject serializedControlPanel = new SerializedObject(controlPanel);
        serializedControlPanel.Update();

        EditorGUILayout.PropertyField(serializedControlPanel.FindProperty("hideShowObject"), true);
        EditorGUILayout.PropertyField(serializedControlPanel.FindProperty("lightControl"), true);

        GUILayout.Label("Objects to Control", EditorStyles.boldLabel);
        SerializedProperty objectsProperty = serializedControlPanel.FindProperty("objects");
        EditorGUILayout.PropertyField(objectsProperty, true);

        GUILayout.Label("Lights to Control", EditorStyles.boldLabel);
        SerializedProperty lightsProperty = serializedControlPanel.FindProperty("lights");
        EditorGUILayout.PropertyField(lightsProperty, true);

        for (int i = 0; i < controlPanel.lights.Count; i++)
        {
            if (controlPanel.lights[i] != null)
            {
                controlPanel.lights[i].color = EditorGUILayout.ColorField($"Light {i + 1} Color", controlPanel.lights[i].color);
            }
        }

        if (GUILayout.Button("Update Objects State"))
        {
            controlPanel.UpdateObjectsState();
        }

        if (GUILayout.Button("Update Light State"))
        {
            controlPanel.UpdateLightState();
        }

        serializedControlPanel.ApplyModifiedProperties();
        EditorUtility.SetDirty(controlPanel);
    }
}
