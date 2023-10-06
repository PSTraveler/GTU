using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindRoom : MonoBehaviour
{
    public GameObject player;
    public float windpower, windtime;
    bool isRoom = false;
    bool isWind = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isRoom = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isRoom = false;
            isWind = false;
            player.GetComponent<Rigidbody2D>().gravityScale = 2;
        }
        
    }

    void Start()
    {
        StartCoroutine(ChangeWind());
    }

    IEnumerator ChangeWind()
    {
        while (true)
        {
            if (isRoom)
            {
                if (isWind)
                {
                    player.GetComponent<Rigidbody2D>().gravityScale = 2;
                    Debug.Log("EndWind");
                    isWind = false;
                }
                else
                {
                    player.GetComponent<Rigidbody2D>().gravityScale = windpower;
                    Debug.Log("StartWind");
                    isWind = true;
                }
                yield return new WaitForSeconds(windtime);
            }
            else yield return null;
        }
    }
}
