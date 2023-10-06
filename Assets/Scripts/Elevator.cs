using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Elevator : MonoBehaviour
{
    public GameObject DoorSwitch, Floor, Player, Ground, Wall, TElevator;
    public JoystickValue JValue;
    float firstY = 0;
    public float finalY = 0, speed = 0;
    Vector3 normalV;
    bool isActive = false;
    bool isDone = false;

    private void Start()
    {
        firstY = Floor.transform.position.y;
        if (firstY > finalY)
            normalV = Vector3.down;
        else
            normalV = Vector3.up;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (!isActive && !isDone && (Floor.transform.position.y == firstY) && DoorSwitch.GetComponent<Script_Switch>().isDone)
            {
                if (Input.GetKeyDown(KeyCode.F) || JValue.actionTouch)
                {
                    Ground.SetActive(false);
                    Wall.SetActive(false);
                    TElevator.SetActive(true);
                    isActive = true;
                    Player = collision.gameObject;
                    Debug.Log("Activated");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && Math.Abs(Floor.transform.position.y - finalY) > 0.05)
        {
            Floor.transform.Translate(normalV * speed * Time.deltaTime);
            Player.transform.Translate(normalV * speed * Time.deltaTime);
        }

        if (isActive && Math.Abs(Floor.transform.position.y - finalY) <= 5.0)
        {
            speed = Math.Abs(Floor.transform.position.y - finalY) * 2;
        }

        if (isActive && Math.Abs(Floor.transform.position.y - finalY) <= 0.05 && !isDone)
        {
            Floor.transform.Translate(normalV * 0);
            Player.transform.Translate(normalV * 0);
            isActive = false;
            isDone = true;
        }

        if (isDone)
        {
            if (Input.GetKeyDown(KeyCode.F) || JValue.actionTouch)
            {
                Ground.SetActive(true);
                Wall.SetActive(true);
                TElevator.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
