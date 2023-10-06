using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enable : MonoBehaviour
{
    public GameObject obj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            obj.SetActive(true);
        }
    }
}
