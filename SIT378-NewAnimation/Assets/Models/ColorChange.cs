using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color randomlySelectedColor;

    private void OnCollisionEnter( Collision other)
    {
         randomlySelectedColor = GetRandomColor();
        GetComponent<Renderer>().material.color = randomlySelectedColor;
    }
    private Color GetRandomColor()
    {
        return new Color(
            r: UnityEngine.Random.Range(0f, 1f),
            g: UnityEngine.Random.Range(0f, 1f),
            b: UnityEngine.Random.Range(0f, 1f));
        
    }

}
