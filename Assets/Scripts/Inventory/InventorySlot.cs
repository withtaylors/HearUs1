using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI itemCount_Text;

    public void Additem(Item _item) {
        icon.sprite = _item.itemIcon;           // ���� ������ ����
        Color color = icon.color;
        color.a = 255f;
        icon.color = color;                     // ���� �̹����� ���� �� ����
        if(Item.ItemType.�Ҹ�ǰ == _item.itemType) // �������� �Ҹ�ǰ�� ��� ���� ǥ��
        {
            if (_item.itemCount > 0)
            {
                itemCount_Text.text = _item.itemCount.ToString();
            }
            else
                itemCount_Text.text = "";
        }
    }

    public void setItemCount(Item _item)
    {
            if (_item.itemCount > 0)
            {
                _item.itemCount += 1;
                itemCount_Text.text = _item.itemCount.ToString();
            }
            else
                itemCount_Text.text = "";
    }

    public void RemoveItem()
    {
        itemCount_Text.text = "";
        icon.sprite = null;
    }
}
