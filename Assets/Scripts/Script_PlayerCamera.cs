using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerCamera : MonoBehaviour
{
    public GameObject A;
    Transform AT;
    // Start is called before the first frame update
    void Start()
    {
        AT = A.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, AT.position, 2f * Time.deltaTime);
        transform.Translate(0, 0, -10);
    }
}
