using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private Draggable _lastDragged;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            _screenPosition = new Vector2(mousePosition.x, mousePosition.y);
        }
        else if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
        }
    }

    private void InitDrag()
    {

    }

    private void Drag()
    {

    }

    private void Drop()
    {

    }
}
