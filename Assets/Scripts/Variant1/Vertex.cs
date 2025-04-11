using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    [SerializeField] private Manager _manager;
    [SerializeField] private TextMeshPro _textMeshPro;
    [SerializeField] private VertexManagement _management;

    private string _name;
    private Vector2 _position;
    private int _orderNumber;
    private float _angle;
    private Vertex[] _connectedVertices;
    private float[] _connectedSegments;
    private string _vertexNameLine = "Имя вершины: ";
    private string _xPositionLine = "Позиция X: ";
    private string _yPositionLine = "Позиция Y: ";
    private string _lineBreakSign = "\n";
    private bool _isActive;

    public bool IsActive => _isActive;
    private bool _isInPolygon => _connectedVertices.Length > 0;

    private void OnEnable()
    {

        _name = gameObject.name;
        _position = transform.position;
    }

    private void ShowInfo()
    {
        _textMeshPro.text = _vertexNameLine + _name + _lineBreakSign +
                            _xPositionLine + _lineBreakSign + _yPositionLine;
    }

    public void SubscribeToManager()
    {
        _manager.ChangingPosition += SetPosition;
        _manager.ChanginName += SetName;
    }

    public void UnsibscribeFromManager()
    {
        _manager.ChangingPosition -= SetPosition;
        _manager.ChanginName -= SetName;
    }

    private void SetPosition(int xPosition, int yPosition)
    {

    }

    private void SetName(string name)
    {

    }
}
