using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop_UI : MonoBehaviour
{
    /*
        container and ShopItemTemplate are used to get refrence to the ui elements within the game scene
        ShopInterface isn't working as intended but is supposed to assist in buying the items
    */
    private Transform container;
    private Transform ShopItemTemplate;

    private CoinCounter CoinCounter; 
    private bool isShowing;

    

    private void Awake(){                                               //This is just to setup and find the correct assets within the game scene
        CoinCounter = new CoinCounter();
        container = transform.Find("container");
        ShopItemTemplate = container.Find("ShopItemTemplate");
        ShopItemTemplate.gameObject.SetActive(false);                   //Makes the actual template invisable to allow for the real items to be displayed
    }

    private void Start(){                                              //Creating the buttons for each item, getting the required information from the Items script
        
        CreateItemButton(Items.ItemType.Brains, Items.GetSprite(Items.ItemType.Brains),"Brains", Items.GetCost(Items.ItemType.Brains), 0);
        CreateItemButton(Items.ItemType.HealthPotion, Items.GetSprite(Items.ItemType.HealthPotion),"Healing Potion", Items.GetCost(Items.ItemType.HealthPotion), 1);
        
        Hide();                                                         //Starts the game off with the menu hidden
    }

    private void CreateItemButton(Items.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex){
    //Uses the ShopItemTemplate to create the Button for each of the items
        Transform ShopItemTransform = Instantiate(ShopItemTemplate, container);
        ShopItemTransform.gameObject.SetActive(true);
        

        float shopItemHeight = 30f;
        ShopItemTransform.Translate(0, (-shopItemHeight * positionIndex)*3, 0);     //Makes sure that the items are spaced out
        //The following updates the text, price and image for each new item
        ShopItemTransform.Find("NameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        ShopItemTransform.Find("PriceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        ShopItemTransform.Find("IconImage").GetComponent<Image>().sprite = itemSprite;

        //This adds the clicking functionality to the items, runs TryToBuy() and checks that the player has enough coins for the item pressed
        Button ShopButton = ShopItemTransform.GetComponent<Button>();  
        ShopButton.onClick.AddListener(() => TryToBuy(itemCost));

        
    }

    private void TryToBuy(int itemCost){       //Checking the amount of current coins to make sure they have enough and if they do, subtract that amount from total
        if(CoinCounter.coins >= itemCost){
            CoinCounter.coins = CoinCounter.coins - itemCost;
            
        }
    
    }

    public void Show(){      //Displays the shop
        if(isShowing == false){
            isShowing = true;
            gameObject.SetActive(true);
        }
        else {
            Hide();
        }
    }
    
    public void Hide(){                        //Hides the shop 
        gameObject.SetActive(false);          
        isShowing = false;
    }
}
