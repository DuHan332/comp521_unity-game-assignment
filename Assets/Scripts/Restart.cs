using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Go to the playground Scene again
    public void RestartGame()
    {
        SceneManager.LoadScene("Playground", LoadSceneMode.Single);
    }
    void Start()
    {
        // Unlock the cursor so buttons can be clicked
        Cursor.lockState = CursorLockMode.None;
    }
}
