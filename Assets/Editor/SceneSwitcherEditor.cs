#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public class SceneDropdownEditor : EditorWindow
{
    private int selectedSceneIndex = 0;

    // Your scenes list (name and path)
    private static readonly string[] sceneNames = { "Main", "OnboardingUI",};
    private static readonly string[] scenePaths = {
        "Assets/Scenes/Main.unity",
        "Assets/Scenes/OnboardingUI.unity",
    };

    [MenuItem("Tools/Scene Dropdown Switcher")]
    public static void ShowWindow()
    {
        GetWindow<SceneDropdownEditor>("Scene Dropdown");
    }

    private void OnGUI()
    {
        GUILayout.Label("Select Scene to Load", EditorStyles.boldLabel);

        // Dropdown popup
        selectedSceneIndex = EditorGUILayout.Popup("Scene", selectedSceneIndex, sceneNames);

        GUILayout.Space(10);

        if (GUILayout.Button("Load Scene"))
        {
            LoadSelectedScene();
        }
    }

    private void LoadSelectedScene()
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(scenePaths[selectedSceneIndex]);
        }
    }
}
#endif
