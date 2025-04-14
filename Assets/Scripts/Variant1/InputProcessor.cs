using UnityEngine;
using UnityEngine.EventSystems;

public class InputProcessor : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _touchPad;
    [SerializeField] private ContextMenuManager _contextMenuManager;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _vertexLayerMask;

    private Vector2 _latestPosition;
    private Vertex _activeVertex;

    private void OnEnable()
    {
        _touchPad.Touched += ProcessInput;
    }

    private void OnDisable()
    {
        _touchPad.Touched -= ProcessInput;
    }

    private void ProcessInput(Vector3 position, int buttonValue)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buttonValue == Constants.LefttMouseButtonValue)
        {
            RecalculatePosition(position);
            RaycastHit2D hit = Physics2D.Raycast(_latestPosition, Vector2.zero, _vertexLayerMask);

            if (hit.collider)
            {
                AssignVertex(hit, position);
            }
            else
            {
                if (_activeVertex != null)
                {
                    _activeVertex.SetSprite();
                    _activeVertex = null;
                }
            }

            if (_contextMenuManager.IsActive)
                _contextMenuManager.HideContextMenu();
        }
        else if (buttonValue == Constants.RightMouseButtonValue)
        {
            if (_activeVertex)
                _contextMenuManager.ShowContextMenu(_camera.WorldToScreenPoint(_activeVertex.transform.position));
        }
    }

    private void AssignVertex(RaycastHit2D hit, Vector2 position)
    {   
        if (hit.transform.gameObject.TryGetComponent(out Vertex vertex))
        {
            if (_activeVertex != null)
                _activeVertex.SetSprite();

            _activeVertex = vertex;
            _activeVertex.SetSprite();
        }
    }

    private void RecalculatePosition(Vector3 position)
    {
        _latestPosition = _camera.ScreenToWorldPoint(position);
    }
}
