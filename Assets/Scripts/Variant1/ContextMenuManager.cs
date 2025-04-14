using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenuManager : MonoBehaviour
{
    [SerializeField] private RectTransform _canvaseRectTransform;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _contextMenu;
    [SerializeField] private Canvas _canvas;

    public bool IsActive => _canvas.enabled;
    private RectTransform _contextMenuRectTransform;

    private void OnEnable()
    {
        if (_contextMenu.TryGetComponent(out RectTransform rectTransform))
            _contextMenuRectTransform = rectTransform;
    }

    public void ShowContextMenu(Vector3 position)
    {
        TransformToCanvasCoordinates(position);
        _contextMenu.SetActive(enabled);
    }

    public void HideContextMenu()
    {
        _contextMenu.SetActive(enabled == false);
    }

    private void TransformToCanvasCoordinates(Vector3 position)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle
        (
            _canvaseRectTransform, position,
            _canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : _camera,
            out Vector2 anchoredPosition
        );

        _contextMenuRectTransform.anchoredPosition = anchoredPosition;
    }
}
