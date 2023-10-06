using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public JoystickValue value;

    public void OnPointerDown(PointerEventData eventData){
        value.jumpTouch = true;
        Debug.Log("Jump");
    }

    public void OnPointerUp(PointerEventData eventData){
        value.jumpTouch = false;
    }
}
