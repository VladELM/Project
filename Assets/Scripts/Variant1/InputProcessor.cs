using UnityEngine;

public class InputProcessor : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _touchPad;
    [SerializeField] private float _radius;

    private Vector2 _latestPosition;

    [SerializeField] private LayerMask _vertexLayerMask;

    private void OnEnable()
    {
        _touchPad.Touched += ProcessTouch;
    }

    private void OnDisable()
    {
        _touchPad.Touched -= ProcessTouch;
    }

    private void ProcessTouch(Vector2 position)
    {
        RecalculatePosition(position);
        FindVertex();
    }

    private void RecalculatePosition(Vector2 position)
    {
        _latestPosition = _camera.ScreenToWorldPoint(position);
    }

    private void FindVertex()
    {  
        RaycastHit2D hit = Physics2D.Raycast(_latestPosition, Vector2.zero, _vertexLayerMask);

        if (hit.collider != null)
        {
            if (hit.transform.gameObject.TryGetComponent(out Vertex vertex))
                vertex.SetSprite();
        }
    }
}
