using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {


    // Use this for initialization
    void Start() {
        RecolorLevels();
    }
    private void OnEnable()
    {
        RecolorLevels();
    }
    public void RecolorLevels() {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Level");
        
        foreach(GameObject g in gameObjects)
        {
            int level = int.Parse(g.name);
            ColorLayer[] colorLayers = g.GetComponentsInChildren<ColorLayer>();
            foreach(ColorLayer colorLayer in colorLayers)
                colorLayer.ApplyPallet(((float)level - 1f) / ((float)SceneManager.sceneCountInBuildSettings-1f));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
