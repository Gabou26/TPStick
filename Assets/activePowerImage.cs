using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activePowerImage : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spritePowerList;


    // Start is called before the first frame update
    void Start()
    {
        //Invoke("ChangeSprite", 10f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeSprite(Color color)
    {
        spriteRenderer.color = color; 
    }

    void ChangeSprite()
    {
        spriteRenderer.color = Color.black; 
    }
}
