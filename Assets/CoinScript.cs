using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;


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
            gameObject.SetActive(false);
        }
    }
}
