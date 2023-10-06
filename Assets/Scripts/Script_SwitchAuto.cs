using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_SwitchAuto : MonoBehaviour
{
    public GameObject doorup, doordown;
    public float end_x1, end_x2, end_y1, end_y2;

    private Vector3 EndPosition1;
    private Vector3 EndPosition2;

    public float speed = 3f;

    bool isSwitch = false;
    public bool isDone = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            isSwitch = true;
    }

    void Start()
    {
        EndPosition1 = new Vector3(end_x1, end_y1, doorup.transform.position.z);
        EndPosition2 = new Vector3(end_x2, end_y2, doordown.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSwitch && !isDone)
        {
            Vector3 currPosition1 = doorup.transform.position;
            Vector3 currPosition2 = doordown.transform.position;
            doorup.transform.position = Vector3.MoveTowards(currPosition1, EndPosition1, speed * Time.deltaTime);
            doordown.transform.position = Vector3.MoveTowards(currPosition2, EndPosition2, speed * Time.deltaTime);
            if (doorup.transform.position.Equals(EndPosition1) && doordown.transform.position.Equals(EndPosition2))
            {
                isDone = true;
            }
        }
    }
}
