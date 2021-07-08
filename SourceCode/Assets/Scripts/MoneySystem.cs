using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    public int moneyCount;
    public Text moneyText;
    public GameObject joyBarObj;

    public GameObject getSomeMoney;

    public void Awake()
    {
        moneyCount = PlayerPrefs.GetInt("MONEY", 0);
        moneyText.text = PlayerPrefs.GetInt("MONEY", 0).ToString ();
    }

    //ADD MONEY TILL REACHED LIMIT
    public void AddMoney ()
    {
        if (moneyCount > 99999999)
            return;

        moneyCount += 100;
        moneyText.text = moneyCount.ToString();
        PlayerPrefs.SetInt("MONEY", moneyCount);
    }

    //PLAYER ENTRING JOB AREA
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            joyBarObj.SetActive(true);
            getSomeMoney.SetActive(false);
        }
    }

    //PLAYER EXITING JOB AREA
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            joyBarObj.SetActive(false);
    }
}
