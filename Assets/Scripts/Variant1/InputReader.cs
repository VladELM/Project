using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<Vector2> Touched;

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
            Touched?.Invoke(new Vector2(mousePosition.x, mousePosition.y));
    }
}
