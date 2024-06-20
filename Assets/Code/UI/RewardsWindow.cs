using System.Collections.Generic;
using Code.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class RewardsWindow : BaseWindow
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private CanvasUpdate _canvas;
    [SerializeField] private Transform _content;
    [SerializeField] private ItemView _item;
    [SerializeField] private Tooltip _tooltip;

    private List<InventoryItem> _items;
    
    protected override void Awake()
    {
        base.Awake();
        _closeButton.onClick.AddListener(Hide);
    }

    protected override void OnShow(object[] args)
    {
        _titleText.text = (string)args[0];
        _items = (List<InventoryItem>)args[1];
        
        _content.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        _scrollRect.enabled = _items.Count >= 6;
        
        if (_content.transform.childCount > 0)
        {
            foreach(Transform child in _content) Destroy(child.gameObject);
        }
        
        CreateItems(_items);
        
    }

    protected override void OnHide()
    {
        
    }

    private void CreateItems(List<InventoryItem> items)
    {
        foreach (var itemData in items)
        {
            var item = Instantiate(_item, _content);
            item.Init(itemData, Tooltip);
        }
    }
    
    private void Tooltip(bool active, InventoryItem itemData)
    {
        if (_items.Count > 5) _scrollRect.enabled = !active;
        _tooltip.Show(itemData);
        _tooltip.gameObject.SetActive(active);
    }
}