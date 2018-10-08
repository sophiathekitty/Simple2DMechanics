using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ColorLayer : MonoBehaviour {
    public static IntVariable CurrentLevel;
    public ColorPallet.Layer layer;
    public ColorPallet.Layer highlight = ColorPallet.Layer.highlight;
    public ColorPallet pallet;
    public IntVariable currentLevel;

    // Use this for initialization
    private void Awake()
    {
        currentLevel = CurrentLevel;
        ApplyPallet();
    }
    void Start() {
        currentLevel = CurrentLevel;
        ApplyPallet();
    }

    public void ApplyPallet()
    {
        float time;
        if (currentLevel != null && false)
            time = ((float)currentLevel.RuntimeValue - 1f) / ((float)SceneManager.sceneCountInBuildSettings - 1f);
        else
        {
            Scene scene = SceneManager.GetActiveScene();
            time = ((float)scene.buildIndex - 1f) / ((float)SceneManager.sceneCountInBuildSettings - 1f);
        }
        ApplyPallet(time);
    }
    public void ApplyPallet(float time)
    {
        if (pallet == null)
            return;

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

        Image image = GetComponent<Image>();
        if (image != null)
            image.color = pallet.GetColor(layer, time);
    }

}
