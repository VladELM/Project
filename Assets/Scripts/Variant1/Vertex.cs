using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Vertex : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _active;
    [SerializeField] private Sprite _unactive;

    private bool _isActive;

    private void OnEnable()
    {
        _isActive = false;
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
