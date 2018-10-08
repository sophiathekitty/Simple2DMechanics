using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameJolt.UI;
using GameJolt.API;
using UnityEngine.Audio;

public class Menu : MonoBehaviour {
    public SaveObject saveObject;
    public IntVariable currentLevel;
    public AudioMixer mixer;
    public FloatVariable volume;
    public FloatVariable music;
    public FloatVariable sounds;
    public LevelPlaylist playlist;
    private void Awake()
    {
        if (saveObject != null)
            saveObject.LoadData();
        ColorLayer.CurrentLevel = currentLevel;
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
        if (GameJoltAPI.Instance != null)
        {
            RemoteSettingsHolder rsh = GameJoltAPI.Instance.GetComponent<RemoteSettingsHolder>();
            if (rsh != null)
            {
                playlist.LoadPlaylist(rsh.Playlist);
            }
        }

        if (level <= currentLevel.RuntimeValue)
            SceneManager.LoadScene(playlist.NextLevel(level));
        if (level < 1)
            SceneManager.LoadScene(1);
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
