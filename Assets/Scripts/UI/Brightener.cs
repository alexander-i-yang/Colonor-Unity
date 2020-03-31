using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brightener : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    public Color normalColor = Color.white;
    public Color newColor = Color.white;

    // Start is called before the first frame update
    void Start() {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
        NormalSprite();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void ColorSprite() {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = newColor;
    }

    public void TintSprite() {
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = newColor;
    }

    public void NormalSprite() {
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = normalColor;
    }
}