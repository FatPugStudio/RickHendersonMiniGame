using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    GameObject nebula;
    GameObject backgroundGradient;
    SpriteRenderer spriteRendererNebula;
    SpriteRenderer spriteRendererBackgroundGradient;
    Sprite spriteVariable;
    Color backgroundGradientColor;
    public Sprite[] spriteList;
    public Color[] backgroundColors;
    int index;

    void Start()

    {
        nebula = GameObject.Find("Nebula");
        backgroundGradient = GameObject.Find("BackgroundGradient");

        spriteRendererNebula = nebula.GetComponent<SpriteRenderer>();
        spriteRendererBackgroundGradient = nebula.GetComponent<SpriteRenderer>();

    }

    void Update()
    {

    }

    void StartGame()
    {
        index = Random.Range(0, spriteList.Length);
        Sprite spriteVariable = spriteList[index];
        spriteRendererNebula.sprite = spriteVariable as Sprite;

        Color backgroundGradientColor = backgroundColors[index];
        spriteRendererBackgroundGradient.color = backgroundGradientColor;
    }
}
