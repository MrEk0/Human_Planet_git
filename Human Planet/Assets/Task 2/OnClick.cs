using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        Color newColor=new Color();
        newColor.r = Random.Range(0f, 1f);
        newColor.g = Random.Range(0f, 1f);
        newColor.b = Random.Range(0f, 1f);
        newColor.a = 1f;

        spriteRenderer.color = newColor;
    }
}
