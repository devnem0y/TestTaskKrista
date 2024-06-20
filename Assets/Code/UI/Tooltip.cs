using Code.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Image _icon;
    
    public void Show(InventoryItem item)
    {
        _title.text = item.Title;
        _description.text = item.Description;
        _icon.sprite = item.Icon;
    }
}