using UnityEngine;
using UnityEditor;
using UnityToolbarExtender;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class ToolbarSceneSwitcher
{
    static string[] sceneNames = { "Main", "OnboardingUI"};
    static string[] scenePaths = {
        "Assets/Scenes/Main.unity",
        "Assets/Scenes/OnboardingUI.unity",
    };

    static int selectedSceneIndex = 0;

    static ToolbarSceneSwitcher()
    {
        ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
    }

    static void OnToolbarGUI()
    {
        GUILayout.FlexibleSpace();

        GUILayout.Label("Scene:", GUILayout.Width(40));
        selectedSceneIndex = EditorGUILayout.Popup(selectedSceneIndex, sceneNames, GUILayout.Width(100));

        if (GUILayout.Button("Load", GUILayout.Width(50)))
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene(scenePaths[selectedSceneIndex]);
            }
        }
    }
}
