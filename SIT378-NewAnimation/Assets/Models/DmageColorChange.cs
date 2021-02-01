using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColorChange : MonoBehaviour
{
    public Color randomlySelectedColor;

    private void OnTriggerEnter(Collider collider)
    {
        randomlySelectedColor = GetRandomColor();
        GetComponent<Renderer>().material.color = randomlySelectedColor;

        if (collider.gameObject.tag == "Bat")
        {
            Debug.Log("You hurt me!");
        }

    }
    private Color GetRandomColor()
    {
        return new Color(
            r: UnityEngine.Random.Range(0f, 1f),
            g: UnityEngine.Random.Range(0f, 1f),
            b: UnityEngine.Random.Range(0f, 1f));

    }
}
