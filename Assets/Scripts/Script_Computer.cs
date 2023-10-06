using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Computer : MonoBehaviour
{
    public GameObject laser, secret_wall;

    public int inven_Num1, inven_Num2;

    bool isSwitch = false;
    bool isActive1 = false, isActive2 = false;
    public bool isDone1 = false, isDone2 = false;

    // 열쇠 유무
    Inventory inventory;

    // 조이스틱
    public JoystickValue value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("trigger on");
            isSwitch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isSwitch = false;
    }

    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSwitch && (Input.GetKeyDown(KeyCode.F) || value.actionTouch == true) && inventory.slots[inven_Num1].isEmpty == false)
        {
            Debug.Log("switch pushed");
            isActive1 = true;
        }

        if (isActive1 && !isDone1)
        {
            Destroy(laser);
            isDone1 = true;
            isActive1 = false;
        }

        if (isSwitch && (Input.GetKeyDown(KeyCode.F) || value.actionTouch == true) && inventory.slots[inven_Num2].isEmpty == false)
        {
            isActive2 = true;
        }
        if (isActive2 && !isDone2)
        {
            secret_wall.SetActive(true);
            isDone2 = true;
            isActive2 = false;
        }
    }
}
