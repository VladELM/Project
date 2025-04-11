using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayc : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector2 screenPosition = new Vector2(mousePosition.x, mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null)
                Debug.Log(hit.transform.gameObject.name);
        }
    }
}
