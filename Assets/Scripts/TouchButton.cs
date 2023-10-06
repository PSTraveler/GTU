using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public JoystickValue value;

    public void OnPointerDown(PointerEventData eventData){
        value.actionTouch = true;
        Debug.Log("Action");
    }

    public void OnPointerUp(PointerEventData eventData){
        value.actionTouch = false;
    }
}
