using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public SaveObject saveObject;
    public IntVariable currentLevel;
    private void Awake()
    {
        if (saveObject != null)
            saveObject.LoadData();
    }
    public void Continue()
    {
        //Scene scene = SceneManager.GetActiveScene();

        if (currentLevel == null || currentLevel.RuntimeValue == SceneManager.sceneCountInBuildSettings -1)
            LoadLevel(1);
        else
            LoadLevel(currentLevel.RuntimeValue);
    }
    public void Quit()
    {
        if (saveObject != null)
            saveObject.SaveData();
        Application.Quit();
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
