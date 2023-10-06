using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject targetObj;
    public GameObject toObj;
    public JoystickValue JValue;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            targetObj = collision.gameObject;
            Debug.Log("TP");
        }
    }
    private void OnTriggerStay2D(Collider2D collision){
        if(collision.CompareTag("Player") && (Input.GetKeyDown(KeyCode.UpArrow) || JValue.actionTouch)){
            if(toObj.GetComponent<BoxCollider2D>().enabled == false)
            {
                toObj.GetComponent<BoxCollider2D>().enabled = true;
                StartCoroutine(TeleportRoutine());
            }
            else StartCoroutine(TeleportRoutine());
        }
    }
    IEnumerator TeleportRoutine(){
        yield return null;
        targetObj.transform.position = toObj.transform.position;
    }
}
