using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brightener : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    public Color color = Color.white;

    // Start is called before the first frame update
    void Start() {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void ColorSprite() {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = color;
    }

    public void NormalSprite() {
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = color;
    }
}