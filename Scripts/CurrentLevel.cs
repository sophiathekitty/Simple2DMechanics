using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CurrentLevel : MonoBehaviour {
    public IntVariable currentLevel;
    private TextMeshProUGUI text;
    public bool setCurrentLevel = true;
    public bool resetCurrentLevel = false;
    public SaveObject saveObject;
    // Use this for initialization
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(currentLevel.RuntimeValue);
        if (currentLevel != null && setCurrentLevel)
            currentLevel.RuntimeValue = scene.buildIndex;
        else if (currentLevel != null && resetCurrentLevel)
            currentLevel.RuntimeValue = currentLevel.InitialValue;
        if (saveObject != null)
            saveObject.SaveData();
        text = GetComponent<TextMeshProUGUI>();
        if (text != null)
            text.SetText(currentLevel.RuntimeValue.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
