using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

// ������ ����� ������ ��ũ��Ʈ. �������� ȿ������ �ٸ�.

public class ItemUse : MonoBehaviour
{
    public void OnClickUseButton()
    {
        if (Inventory.instance.inventoryItemList.Count > 0)
        {
            if (Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot].itemEffect == Item.ItemEffect.ȸ��) // ȸ�� �������� ���
            {
                PlayerHP.instance.IncreaseHP(Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot].itemEffectValue);
            }
            else if (Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot].itemEffect == Item.ItemEffect.����) // ���� �������� ���
            {
                PlayerHP.instance.DecreaseHP(Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot].itemEffectValue);
            }
    
            if (Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot].itemCount > 1)
            {
                InventorySlot.instance.DecreaseCount(Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot]);
            }
            else
            {
                Inventory.instance.DeleteItem(Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot]);
            }
        }
        else
        {
            Debug.Log("�κ��丮�� �׸��� �������� �ʽ��ϴ�.");
        }

    }
}
