using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ColorLayer : MonoBehaviour {
    public ColorPallet.Layer layer;
    public ColorPallet.Layer highlight = ColorPallet.Layer.highlight;
    public ColorPallet pallet;
    
	// Use this for initialization
	void Start () {
        if (pallet == null)
            return;
        Scene scene = SceneManager.GetActiveScene();
        float time = ((float)scene.buildIndex+1f) / (float)SceneManager.sceneCountInBuildSettings;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer != null)
            spriteRenderer.color = pallet.GetColor(layer,time);

        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        if(particleSystem != null)
        {
            var main = particleSystem.main;
            main.startColor = new ParticleSystem.MinMaxGradient(pallet.GetColor(layer, time), pallet.GetColor(highlight, time));
        }

        Camera camera = GetComponent<Camera>();
        if (camera != null)
        {
            camera.backgroundColor = pallet.GetColor(layer, time);
        }
        TextMeshPro textMeshPro = GetComponent<TextMeshPro>();
        if (textMeshPro != null)
            textMeshPro.color = pallet.GetColor(layer, time);
        TextMeshProUGUI textMeshProGui = GetComponent<TextMeshProUGUI>();
        if (textMeshProGui != null)
            textMeshProGui.color = pallet.GetColor(layer, time);
    }

}
