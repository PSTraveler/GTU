using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_3GateOpen : MonoBehaviour
{
    public GameObject doorup1, doordown1, doorup2, doordown2, doorup3, doordown3;
    public float end_y1, end_y2;

    private Vector2 EndPosition1up, EndPosition1down, EndPosition2up, EndPosition2down, EndPosition3up, EndPosition3down;

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
        Debug.Log("trigger on");
        isSwitch = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isSwitch = false;
    }

    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        EndPosition1up = new Vector2(doorup1.transform.position.x, end_y1);
        EndPosition1down = new Vector2(doordown1.transform.position.x, end_y2);
        EndPosition2up = new Vector2(doorup2.transform.position.x, end_y1);
        EndPosition2down = new Vector2(doordown2.transform.position.x, end_y2);
        EndPosition3up = new Vector2(doorup3.transform.position.x, end_y1);
        EndPosition3down = new Vector2(doordown3.transform.position.x, end_y2);
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
            Dooropen1();
            if ((Vector2)doorup1.transform.position == EndPosition1up && (Vector2)doordown1.transform.position == EndPosition1down)
            {
                Invoke(nameof(Dooropen2), 2);
                if ((Vector2)doorup2.transform.position == EndPosition2up && (Vector2)doordown2.transform.position == EndPosition2down)
                {
                    Invoke(nameof(Dooropen3), 2);
                    if ((Vector2)doorup3.transform.position == EndPosition3up && (Vector2)doordown3.transform.position == EndPosition3down)
                        isDone = true;
                }
            }
        }
    }

    void Dooropen1()
    {
        Vector2 currPosition1up = doorup1.transform.position;
        Vector2 currPosition1down = doordown1.transform.position;
        doorup1.transform.position = Vector2.MoveTowards(currPosition1up, EndPosition1up, speed * Time.deltaTime);
        doordown1.transform.position = Vector2.MoveTowards(currPosition1down, EndPosition1down, speed * Time.deltaTime);
    }

    void Dooropen2()
    {
        Vector2 currPosition2up = doorup2.transform.position;
        Vector2 currPosition2down = doordown2.transform.position;
        doorup2.transform.position = Vector2.MoveTowards(currPosition2up, EndPosition2up, speed * Time.deltaTime);
        doordown2.transform.position = Vector2.MoveTowards(currPosition2down, EndPosition2down, speed * Time.deltaTime);
    }

    void Dooropen3()
    {
        Vector2 currPosition3up = doorup3.transform.position;
        Vector2 currPosition3down = doordown3.transform.position;
        doorup3.transform.position = Vector2.MoveTowards(currPosition3up, EndPosition3up, speed * Time.deltaTime);
        doordown3.transform.position = Vector2.MoveTowards(currPosition3down, EndPosition3down, speed * Time.deltaTime);
    }
}
