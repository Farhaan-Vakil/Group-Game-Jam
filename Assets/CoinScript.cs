using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;
    public AudioSource collect;
    public AudioSource getAll;

    void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
    }

    void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GameObject.Find("CoinText").GetComponent<CoinsText>().coins += 1;
            collect.Play();
            if (GameObject.Find("CoinText").GetComponent<CoinsText>().coins > 5)
            {
                getAll.Play();
            }
        }
    }
}
