using System;
using Unity.VisualScripting;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<Vector3, int> Touched;

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        if (TryToGetButtonValue(out int butttonValue))
            Touched?.Invoke(mousePosition, butttonValue);
    }

    private bool TryToGetButtonValue(out int buttonValue)
    {
        buttonValue = 0;
        bool isPushed = false;

        if (Input.GetMouseButtonDown(Constants.LefttMouseButtonValue))
        {
            buttonValue = Constants.LefttMouseButtonValue;
            isPushed = true;
        }
        else if (Input.GetMouseButtonDown(Constants.RightMouseButtonValue))
        {
            buttonValue = Constants.RightMouseButtonValue;
            isPushed = true;
        }

        return isPushed;
    }
}
