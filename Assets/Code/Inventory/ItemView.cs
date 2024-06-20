using System;
using Code.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private const float HOLD_TIME = 1f;
    
    [SerializeField] private Image _icon;

    private InventoryItem _data;
    private Action<bool, InventoryItem> _action;

    public void Init(InventoryItem data, Action<bool, InventoryItem> action)
    {
        _data = data;
        _icon.sprite = _data.Icon;

        _action = action;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Invoke("OnLongPress", HOLD_TIME);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CancelInvoke("OnLongPress");
        _action?.Invoke(false, _data);
    }
    
    private void OnLongPress()
    {
        _action?.Invoke(true, _data);
    }
}