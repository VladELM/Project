using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VertexManagement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TouchPad _touchPad;
    [SerializeField] private Sprite _active;
    [SerializeField] private Sprite _unactive;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _vertexLayerMask;
    [SerializeField] private float _dragSpeed;

    private bool _isActive;

    private void OnEnable()
    {
        //_touchPad.Touched += SelectVertex;
        //_touchPad.Holding += DragVertex;
        _isActive = false;
    }

    private void OnDisable()
    {
        //_touchPad.Touched -= SelectVertex;
        //_touchPad.Holding -= DragVertex;
    }

    private void SelectVertex()
    {
        //bool isThisVertex = Physics2D.OverlapCircle(_touchPad.LatestPosition, _radius, _vertexLayerMask) == GetComponent<CircleCollider2D>();

        //if (isThisVertex && _isActive == false)
        //    SetSprite();
        //else if (isThisVertex == false && _isActive)
        //    SetSprite();

        //Vector2 direction = _touchPad.LatestPosition -
        //                    new Vector2(_camera.transform.position.x, _camera.transform.position.y);

        //RaycastHit2D hit = Physics2D.Raycast(_camera.transform.position, direction, Mathf.Infinity, _vertexLayerMask);
    }

    private void DragVertex()
    {
        //if (_isActive)
        //    transform.position = _touchPad.LatestPosition;
    }

    public void SetSprite()
    {
        _isActive = !_isActive;

        if (_isActive)
            _spriteRenderer.sprite = _active;
        else
            _spriteRenderer.sprite = _unactive;
    }
}
