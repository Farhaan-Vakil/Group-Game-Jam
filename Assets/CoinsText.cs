using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    public int coins = 0;
    public Text coinText;

    void Update()
    {
        coinText.text = "Coins: " + coins;
    }

}
