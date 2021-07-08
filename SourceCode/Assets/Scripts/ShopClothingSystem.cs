using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopClothingSystem : MonoBehaviour
{
    public MoneySystem moneyIsntace;

    public Text tshirtPriceTag;
    public Button tshirtBuyButton;

    [Header("ITEMS")]
    public GameObject[] tShirts;

    public GameObject[] onPlayerSkin;

    [Header("PRICEING")]
    public int[] tShirtsPrice;
    public int[] boughtShirts;

    [Header("COUNTS")]
    public int tShirtsCount = 0;

    public void Awake()
    {
        ShopItemCheck();
        tShirtsCount = 0;
        ItemEquipped();

        //BUTTON ACTIVATION
        IfItemIsBoughtOrNot();

        //SETTING SHOP TO DEFAULT
        tShirts[tShirtsCount].SetActive(true);

        if (boughtShirts[tShirtsCount] == 0)
            tshirtPriceTag.text = tShirtsPrice[tShirtsCount].ToString() + "$";
        else
            tshirtPriceTag.text = "SELECT";
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DeleteStorePrefabs();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }                  
    }

    //REVEWING CLOTHS
    public void ForwardButton()
    {
        //CHANGING THE ITEM
        if (tShirtsCount < tShirts.Length - 1)
            tShirtsCount++;
        else
            tShirtsCount = 0;

        for (int i = 0; i < tShirts.Length; i++)
        {
            tShirts[i].SetActive(false);
        }
        
        //BUTTON ACTIVATION
        IfItemIsBoughtOrNot();

        tShirts[tShirtsCount].SetActive(true);

        //CHECK IF YOU HAVE NOT BOUGHT THAT ITEM
        if (boughtShirts[tShirtsCount] == 0)
            tshirtPriceTag.text = tShirtsPrice[tShirtsCount].ToString() + "$";
        //AND IF YOU ALREADY BOUGHT YOU CAN SELECT THAT
        else
            tshirtPriceTag.text = "SELECT";
    }

    //WHEN YOU WILL CKICK ON BUY BUTTON
    public void _BuyButtonFunction()
    {
        //IF YOU HAVE NOT BOUGHT THAT ITEM
        if (boughtShirts[tShirtsCount] == 0)
        {
            //IF YOU HAVE MONEY TO BUY THAT ITEM
            
            if (PlayerPrefs.GetInt ("MONEY", 0) >= tShirtsPrice[tShirtsCount])
            {
                //WILL REDUCE MONEY FROM PLAYER INFO
                PlayerPrefs.SetInt("MONEY", PlayerPrefs.GetInt("MONEY") - tShirtsPrice[tShirtsCount]);
                moneyIsntace.moneyCount = PlayerPrefs.GetInt("MONEY", 0);
                moneyIsntace.moneyText.text = PlayerPrefs.GetInt("MONEY").ToString();   //DISPLAY ON SCREEN
                //WILL CHECK THAT YOU GOT THAT ITEM
                boughtShirts[tShirtsCount] = 1;
                //TO KEEP CHECK WHICH ITEM PLAYER BOUGHT
                BoughtList();
                tshirtPriceTag.text = "SELECT";
            }
        }
        //ITEM ALREADY BOUGHT 
        else if (boughtShirts[tShirtsCount] == 1)
        {
            tshirtBuyButton.interactable = false;
            BuyButtonIfSelected();
        }
        //ITEM IN USE
        else if (boughtShirts[tShirtsCount] == 2)
            tshirtBuyButton.interactable = false;
    }

    //BOUGHT ITEM WILL BE FLAGED AS 1
    public void BoughtList ()
    {
        if (tShirtsCount == 0)
            PlayerPrefs.SetInt("S0", 1);

        else if (tShirtsCount == 1)
            PlayerPrefs.SetInt("S1", 1);

        else if (tShirtsCount == 2)
            PlayerPrefs.SetInt("S2", 1);

        else if (tShirtsCount == 3)
            PlayerPrefs.SetInt("S3", 1);

        else if (tShirtsCount == 4)
            PlayerPrefs.SetInt("S4", 1);

        else if (tShirtsCount == 5)
            PlayerPrefs.SetInt("S5", 1);
    }

    //TO IDENTIFY WHICH ITEM PLAYER BOUGHT 
    public void ShopItemCheck ()
    {
        boughtShirts[0] = PlayerPrefs.GetInt("S0", 0);
        boughtShirts[1] = PlayerPrefs.GetInt("S1", 0);
        boughtShirts[2] = PlayerPrefs.GetInt("S2", 0);
        boughtShirts[3] = PlayerPrefs.GetInt("S3", 0);
        boughtShirts[4] = PlayerPrefs.GetInt("S4", 0);
        boughtShirts[5] = PlayerPrefs.GetInt("S5", 0);
    }

    //IF ITEM ALREADY BOUGHT WILL BE EQUIPPED BY PLAYER
    public void BuyButtonIfSelected ()
    {
        //ITEM BEING USED WILL BE FLAGED BY 2

        //EREASING PREVIOUSLY BOUGHT ITEM
        if (boughtShirts[0] == 2)
        {
            PlayerPrefs.SetInt("S0", 1);
        }

        else if (boughtShirts[1] == 2)
        {
            PlayerPrefs.SetInt("S1", 1);
        }

        else if (boughtShirts[2] == 2)
        {
            PlayerPrefs.SetInt("S2", 1);
        }

        else if (boughtShirts[3] == 2)
        {
            PlayerPrefs.SetInt("S3", 1);
        }

        else if (boughtShirts[4] == 2)
        {
            PlayerPrefs.SetInt("S4", 1);
        }

        else if (boughtShirts[5] == 2)
        {
            PlayerPrefs.SetInt("S5", 1);
        }

        ShopItemCheck();

        //SETTING NEW BOUGHT ITEM
        if (tShirtsCount == 0)
            PlayerPrefs.SetInt("S0", 2);

        else if (tShirtsCount == 1)
            PlayerPrefs.SetInt("S1", 2);

        else if (tShirtsCount == 2)
            PlayerPrefs.SetInt("S2", 2);

        else if (tShirtsCount == 3)
            PlayerPrefs.SetInt("S3", 2);

        else if (tShirtsCount == 4)
            PlayerPrefs.SetInt("S4", 2);

        else if (tShirtsCount == 5)
            PlayerPrefs.SetInt("S5", 2);

        ShopItemCheck();
        ItemEquipped();
    }

    public void selectingCloths (GameObject activeItem)
    {
        for (int i = 0; i < onPlayerSkin.Length; i++)
        {
            onPlayerSkin[i].SetActive(false);
        }

        activeItem.SetActive(true);
    }

    public void ItemEquipped ()
    {
        //USING THE CHOOSEN ITEM
        if (boughtShirts[0] == 2)
            selectingCloths(onPlayerSkin[0]);
        
        else if (boughtShirts[1] == 2)
            selectingCloths(onPlayerSkin[1]);

        else if (boughtShirts[2] == 2)
            selectingCloths(onPlayerSkin[2]);

        else if (boughtShirts[3] == 2)
            selectingCloths(onPlayerSkin[3]);

        else if (boughtShirts[4] == 2)
            selectingCloths(onPlayerSkin[4]);

        else if (boughtShirts[5] == 2)
            selectingCloths(onPlayerSkin[5]);

    }

    public void IfItemIsBoughtOrNot ()
    {
        //BUTTON ACTIVATION
        if (boughtShirts[tShirtsCount] == 0)
            tshirtBuyButton.interactable = true;

        else if (boughtShirts[tShirtsCount] == 1)
            tshirtBuyButton.interactable = true;

        else if (boughtShirts[tShirtsCount] == 2)
            tshirtBuyButton.interactable = false;
    }

    public void DeleteStorePrefabs ()
    {
        PlayerPrefs.DeleteKey("S0");
        PlayerPrefs.DeleteKey("S1");
        PlayerPrefs.DeleteKey("S2");
        PlayerPrefs.DeleteKey("S3");
        PlayerPrefs.DeleteKey("S4");
        PlayerPrefs.DeleteKey("S5");

        PlayerPrefs.DeleteKey("MONEY");
    }
}
