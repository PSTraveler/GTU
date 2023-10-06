using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    RectTransform rect;
    Vector2 touch = Vector2.zero;
    public RectTransform handle;
    float widthHalf;
    public JoystickValue value;

    private void Start(){
        rect = GetComponent<RectTransform>();
        widthHalf = rect.sizeDelta.x * 0.5f;
    }

    public void OnDrag(PointerEventData eventData){
        touch = (eventData.position - rect.anchoredPosition) / widthHalf;
        if(touch.magnitude > 1)
            touch = touch.normalized;
        value.joyTouch = touch;
        handle.anchoredPosition = touch * widthHalf;
    }

    public void OnPointerDown(PointerEventData eventData){
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData){
        value.joyTouch = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
