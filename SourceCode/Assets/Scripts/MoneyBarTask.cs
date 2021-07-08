using UnityEngine;

public class MoneyBarTask : MonoBehaviour
{
    public MoneySystem moneyInstance;

    //ADD MONEY WHEN ANIMATON ENDS
    public void _AddMoney() => moneyInstance.AddMoney();
}
