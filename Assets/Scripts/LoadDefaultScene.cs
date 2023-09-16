using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class LoadDefaultScene
{
    static LoadDefaultScene()
    {   
        // Load the main scene(the first scene) when this project is imported to avoid any misunderstanding
        UnityEditor.SceneManagement.EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>("Assets/Scenes/Playground.unity");
    }
}
