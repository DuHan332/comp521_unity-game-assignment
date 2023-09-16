using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class LoadDefaultScene
{
    static LoadDefaultScene()
    {
        UnityEditor.SceneManagement.EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>("Assets/Scenes/Playground.unity");
    }
}
