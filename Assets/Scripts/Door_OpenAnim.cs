using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_OpenAnim : MonoBehaviour
{
    public Animator animator;

    // 열쇠 유무
    Inventory inventory;
    
    // 조이스틱
    public JoystickValue value;

    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        animator = GetComponent<Animator>();        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (Input.GetKeyDown(KeyCode.F) || value.actionTouch == true) && inventory.slots[0].isEmpty == false)
        {
            animator.SetTrigger("open");
        }
    }
}
