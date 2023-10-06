using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject slotItem;

    // 조이스틱
    public JoystickValue value;

    private void OnTriggerStay2D(Collider2D collision){
        if(collision.CompareTag("Player") && (Input.GetKeyDown(KeyCode.F) || value.actionTouch == true)){
            Inventory inven = collision.GetComponent<Inventory>();
            for(int i = 0; i < inven.slots.Count; i++){
                if(inven.slots[i].isEmpty){
                    Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                    inven.slots[i].isEmpty = false;
                    Destroy(this.gameObject);
                    break;
                }
            }
        }
    }
}
