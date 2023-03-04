using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public string Stage;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(Stage);
            GameObject.Find("CoinText").GetComponent<CoinsText>().coins = 0;
        }
    }
}
