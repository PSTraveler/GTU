using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Script_Elevator : MonoBehaviour
{
    public GameObject ElevatorSW, ElevatorFloor;
    Vector2 EndPosition = new Vector2(51, 34.75f);
    public float speed = 10f;
    private Script_Switch SWScript;
    bool isRide = false;
    Rigidbody2D rigdbody;

    // 조이스틱
    public JoystickValue value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isRide = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isRide = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isRide = false;
    }

    private void Awake()
    {
        SWScript = ElevatorSW.GetComponent<Script_Switch>();
        rigdbody = ElevatorFloor.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)ElevatorFloor.transform.position == EndPosition)
            gameObject.GetComponent<Script_Elevator>().enabled = false;
    }

    void FixedUpdate()
    {
        if (SWScript.isDone && (Input.GetKeyDown(KeyCode.F) || value.actionTouch == true) && isRide)
        {
            rigdbody.gravityScale = -3;
        }
    }
}
