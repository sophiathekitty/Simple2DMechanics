using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameJolt.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour {
    public SaveObject saveObject;
    public IntVariable currentLevel;
    public AudioMixer mixer;
    public FloatVariable volume;
    public FloatVariable music;
    public FloatVariable sounds;
    private void Awake()
    {
        if (saveObject != null)
            saveObject.LoadData();
    }

    public void ApplyVolume()
    {
        mixer.SetFloat("MasterVolume", volume.RuntimeValue);
        mixer.SetFloat("MusicVolume", music.RuntimeValue);
        mixer.SetFloat("SoundFXVolume", sounds.RuntimeValue);
    }
    public void DefaultVolumes()
    {
        volume.RuntimeValue = volume.InitialValue;
        music.RuntimeValue = music.InitialValue;
        sounds.RuntimeValue = sounds.InitialValue;
    }

    public void Continue()
    {
        //Scene scene = SceneManager.GetActiveScene();
        if (saveObject != null)
            saveObject.SaveData();

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
        if(level <= currentLevel.RuntimeValue)
            SceneManager.LoadScene(level);
    }

    public void ShowTrophies()
    {
        GameJoltUI.Instance.ShowTrophies();
    }
    public void ShowScores()
    {
        GameJoltUI.Instance.ShowLeaderboards();
    }
}
