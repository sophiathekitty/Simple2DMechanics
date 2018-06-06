using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public SaveObject saveObject;
    public IntVariable currentLevel;
    public void Continue()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (currentLevel == null)
            LoadLevel(1);
        else
            LoadLevel(currentLevel.RuntimeValue);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
