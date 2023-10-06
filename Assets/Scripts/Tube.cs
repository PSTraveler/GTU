using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    public GameObject player;
    public JoystickValue JValue;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || JValue.actionTouch)
        {
            if (!gameObject.GetComponent<Animator>().GetBool("Break1"))
                gameObject.GetComponent<Animator>().SetBool("Keep", false);
            else if (!gameObject.GetComponent<Animator>().GetBool("Break2"))
                gameObject.GetComponent<Animator>().SetBool("Break2", true);
            else
            {
                gameObject.GetComponent<Animator>().SetBool("Break3", true);
                gameObject.transform.Translate(0, 0, 8);
                player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                player.GetComponent<Player>().enabled = true;
                gameObject.GetComponent<Tube>().enabled = false;
            }
        }
    }
}
