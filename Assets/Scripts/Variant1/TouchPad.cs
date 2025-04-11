using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TouchPad : MonoBehaviour
{
    private int _touchIndex = 0;

    public delegate void LatestPositionSender(Vector2 vector);
    public event LatestPositionSender Touched;
    public event LatestPositionSender Holding;

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(_touchIndex);

            if (touch.phase == TouchPhase.Began)
                Touched?.Invoke(new Vector2(touch.position.x, touch.position.y));
            else if (touch.phase == TouchPhase.Moved)
                Holding?.Invoke(new Vector2(touch.position.x, touch.position.y));
        }

        #if UNITY_EDITOR
        Vector3 mousePosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
            Touched?.Invoke(new Vector2(mousePosition.x, mousePosition.y));
        else if (Input.GetMouseButton(0))
            Holding?.Invoke(new Vector2(mousePosition.x, mousePosition.y));

        #endif

    }
}
