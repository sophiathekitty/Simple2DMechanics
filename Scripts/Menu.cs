using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public void Continue()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 0)
            SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 0)
            Application.Quit();
        else
            SceneManager.LoadScene(0);

    }
}
