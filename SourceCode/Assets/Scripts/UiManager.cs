using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //MR SHOPKEEPER
    public GameObject mrShopkeeper;
    public GameObject wantToShop;
    public GameObject dontWantToShop;
    public GameObject IfShopped;

    public Transform mrShopkeeperNameHolder;
    //JOBS
    public GameObject getSomeMoney;
    public Transform getSomeMoneyHolder;

    //FOR BUTTON SOUND
    public AudioSource buttonSoundSource;
    public AudioClip buttonSoundClip;
    
    public AudioSource buyButtonSoundSource;
    public AudioClip buyButtonSoundClip;
    

    [Header ("MONEY SYSTEM")]
    public GameObject moneyBar;
    public Transform moneyBarHolder;

    public void Awake()
    {
        wantToShop.SetActive(false);

        //MONEY BAR
        moneyBar.SetActive(false);
    }

    //PLACING UI TEXTS AND IMAGIES AT DESIRE PLACES
    public void Update()
    {
        mrShopkeeper.transform.position = Camera.main.WorldToScreenPoint(mrShopkeeperNameHolder.position + new Vector3(0, 0.4f, 0));
        wantToShop.transform.position = Camera.main.WorldToScreenPoint(mrShopkeeperNameHolder.position + new Vector3(0, 0.4f, 0));
        dontWantToShop.transform.position = Camera.main.WorldToScreenPoint(mrShopkeeperNameHolder.position + new Vector3(0, 0.4f, 0));
        IfShopped.transform.position = Camera.main.WorldToScreenPoint(mrShopkeeperNameHolder.position + new Vector3(0, 0.4f, 0));
        
        //MONEY BAR
        moneyBar.transform.position = Camera.main.WorldToScreenPoint(moneyBarHolder.position + new Vector3(0, 0.4f, 0));

        //JOBS
        getSomeMoney.transform.position = Camera.main.WorldToScreenPoint(getSomeMoneyHolder.position + new Vector3(0, 0.4f, 0));
    }

    public void _ButtonSound () => buttonSoundSource.PlayOneShot(buttonSoundClip);
    public void _BuyButtonSound () => buyButtonSoundSource.PlayOneShot(buyButtonSoundClip);
}
