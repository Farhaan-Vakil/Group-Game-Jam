using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;
    public AudioSource collect;
    public AudioSource getAll;
    public int level = 1;

    void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
    }

    void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            GameObject.Find("CoinText").GetComponent<CoinsText>().coins++;
            collect.Play();
            if (GameObject.Find("CoinText").GetComponent<CoinsText>().coins > 5)
            {
                getAll.Play();
                if (level == 1)
                    Application.LoadLevel("Level 2");
                if (level == 2)
                    //win
                    GameObject.Find("CoinText").GetComponent<CoinsText>().coins = 0;
                level += 1;
            }
            gameObject.SetActive(false);
        }
    }
}
