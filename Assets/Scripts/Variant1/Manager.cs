using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UIElements;

public class Manager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private TouchPad _touchPad;
    [SerializeField] private float _radius;

    private Vector2 _latestPosition;
    private Coroutine _coroutine;
    private float _delay = 0.5f;
    private bool _isButtonPushed;

    [SerializeField] private LayerMask _vertexLayerMask;

    private Vertex _vertex;

    public delegate void VertexNameChanger(string name);
    public event VertexNameChanger ChanginName;

    public delegate void VertexPositionChanger(int xPosition, int yPosition);
    public event VertexPositionChanger ChangingPosition;

    public event Action Subcribing;

    private void Start()
    {
        _isButtonPushed = false;
    }

    private void OnEnable()
    {
        _touchPad.Touched += ProcessTouch;

        _touchPad.Holding += ProcessHolding;
    }

    private void OnDisable()
    {
        _touchPad.Touched -= ProcessTouch;

        _touchPad.Holding -= ProcessHolding;
    }

    private void ProcessTouch(Vector2 position)
    {
        RecalculatePosition(position);
        FindVertex();
        
        if (_vertex)
            ProcessEmptySpace();

        DebugPushing();
    }

    private void ProcessHolding(Vector2 position)
    {

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
            if (hit.transform.gameObject.TryGetComponent(out VertexManagement vertex))
                vertex.SetSprite();
        }
    }

    private void ProcessEmptySpace()
    {
        
    }

    private void DebugPushing()
    {
        if (_isButtonPushed)
        {
            Debug.Log("Pushed!");
            _isButtonPushed = false;
        }
    }

    public void SetMode()
    {
        _isButtonPushed = true;
    }
}
