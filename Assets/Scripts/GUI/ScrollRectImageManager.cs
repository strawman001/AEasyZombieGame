using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRectImageManager : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private float[] levelArray = new float[] {0, 0.5f, 1};
    private float targetPosition = 0;
    private bool isDrag = false;

    public ScrollRect scorllRect;
    public Toggle[] toggleArray;
    public float smooth = 5;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrag == false)
        {
            scorllRect.horizontalNormalizedPosition = Mathf.Lerp(
                scorllRect.horizontalNormalizedPosition,
                targetPosition,
                Time.deltaTime * smooth);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        float posX = scorllRect.horizontalNormalizedPosition;
        int index = 0;
        float offset = Mathf.Abs(levelArray[index] - posX);
        for (int i = 0; i < levelArray.Length; i++)
        {
            float offsetTmp = Mathf.Abs(levelArray[i] - posX);
            if (offsetTmp < offset)
            {
                index = i;
                offset = offsetTmp;
            }
        }
        targetPosition = levelArray[index];
        toggleArray[index].isOn = true;
        print(scorllRect.horizontalNormalizedPosition);
    }

    public void MoveToLevel1(bool isOn)
    {
        if (isOn == true)
        {
            targetPosition = levelArray[0];
        }
    }
    public void MoveToLevel2(bool isOn)
    {
        if (isOn == true)
        {
            targetPosition = levelArray[1];
        }
    }
    public void MoveToLevel3(bool isOn)
    {
        if (isOn == true)
        {
            targetPosition = levelArray[2];
        }
    }
}
