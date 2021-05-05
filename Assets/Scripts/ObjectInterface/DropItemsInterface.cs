using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class DropItemsInterface : MonoBehaviour
{
    public List<GameObject> dropItemsList;
    public int dropItemNum;
    public List<int> dropItemsProbability;

    private int totalValue = 0;
    private Random random = new Random();
    private void Start()
    {
        foreach (int weight in dropItemsProbability)
        {
            totalValue += weight;
        }
    }

    public void DropItems(Vector3 position)
    {
        if (dropItemsList.Count!=0)
        {
            for (int i = 0; i < dropItemNum; i++)
            {
                GameObject item = ConfirmDropItem();
                Instantiate(item, position, item.transform.rotation);
            }
        }
    }

    public GameObject ConfirmDropItem()
    {
        if (dropItemsProbability.Count!=dropItemsList.Count)
        {
            return dropItemsList[random.Next(dropItemsList.Count)];
        }
        else
        {
            int randomNum = random.Next(totalValue);
            int tempTotalvalue = 0;
            for (int i = 0; i < dropItemsProbability.Count; i++)
            {
                tempTotalvalue += dropItemsProbability[i];
                if (randomNum<tempTotalvalue)
                {
                    return dropItemsList[i];
                }
            }
        }

        return dropItemsList[0];
    }

}
