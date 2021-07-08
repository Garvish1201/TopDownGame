using UnityEngine;

public class ShopUiManager : MonoBehaviour
{
    [Header ("COMPONENTS")]
    public PlayerMovement playerInstance;

    [Header ("VARIABLES")]
    //PLAYER AWAY FROM SHOP
    public GameObject nameTag;

    //PLAYER NEAR FROM SHOP
    public GameObject wantsToShopOption;

    //OPTION WHILE SHOPPING
    public GameObject dontWantToShop;
    public GameObject shopPannel;

    //OPTION AFTER SHOPPING
    public GameObject IfShopped;

    public bool playerIsShopping = false;


    public void Awake() => ScreenToBeActive(nameTag);

    //PLAYER ENTRING SHOP AREA
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Player") && !playerIsShopping)
            ScreenToBeActive(wantsToShopOption);
    }
    
    //PLAYER EXITING SHOP AREA
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag ("Player"))
            ScreenToBeActive(nameTag); 
    }

    //SHOP FUNCTION
    public void AcceptButton()
    {
        playerIsShopping = true;
        playerInstance.canMove = false;
        ScreenToBeActive(shopPannel);
    }
    public void DeclineButton () => ScreenToBeActive(dontWantToShop);


    //EXITING SHOP
    public void __ShopExitButton ()
    {
        playerIsShopping = false;
        playerInstance.canMove = true;
        ScreenToBeActive(IfShopped);
    }

    //ACTIVATING DESIRED PANNEL
    public void ScreenToBeActive (GameObject activeScreen)
    {
        nameTag.SetActive(false);
        wantsToShopOption.SetActive(false);
        dontWantToShop.SetActive(false);
        shopPannel.SetActive(false);
        IfShopped.SetActive(false);

        activeScreen.SetActive(true);
    }
}
