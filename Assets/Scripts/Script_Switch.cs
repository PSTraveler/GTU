using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Script_Switch : MonoBehaviour
{
    public GameObject doorup, doordown;
    public float end_x1, end_x2, end_y1, end_y2;

    private Vector3 EndPosition1;
    private Vector3 EndPosition2;

    public float speed = 3f;

    bool isSwitch = false;
    bool isActive = false;
    public bool isDone = false;

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
        EndPosition1 = new Vector3(end_x1, end_y1, doorup.transform.position.z);
        EndPosition2 = new Vector3(end_x2, end_y2, doordown.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSwitch && (Input.GetKeyDown(KeyCode.F) || value.actionTouch == true) && inventory.slots[0].isEmpty == false)
        {
            Debug.Log("switch pushed");
            isActive = true;
        }

        if (isActive && !isDone)
        {
            Vector3 currPosition1 = doorup.transform.position;
            Vector3 currPosition2 = doordown.transform.position;
            doorup.transform.position = Vector3.MoveTowards(currPosition1, EndPosition1, speed * Time.deltaTime);
            doordown.transform.position = Vector3.MoveTowards(currPosition2, EndPosition2, speed * Time.deltaTime);
            if (doorup.transform.position.Equals(EndPosition1) && doordown.transform.position.Equals(EndPosition2))
            {
                isActive = false;
                isDone = true;
            }
        }
    }
}
