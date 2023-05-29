using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    private List<InventorySlot> craftingSlots;
    public Transform tf_craftingSlots;

    public List<Item> craftingItemList;

    public CraftingCombination craftingCombination; // ũ������ ���� ��ü

    private void Start()
    {
        craftingSlots = new List<InventorySlot>(tf_craftingSlots.GetComponentsInChildren<InventorySlot>());
        craftingItemList = new List<Item>();
    }

    public void onCiickSelectButton()
    {
        if (craftingItemList.Count > 0)
        {
            for (int i = 0; i < craftingItemList.Count; i++) // ũ������ ������ ����Ʈ�� ������ �������� �ִ��� �˻�
            {
                CheckItemAmount(i);

                if (craftingItemList[i].itemID == Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot].itemID)
                {
                    craftingItemList[i].itemCount += 1;
                    return;
                }
            }
        if (craftingItemList.Count == 3)                     // ������ ���� �� �� ���
            {
                Debug.Log("�� ������ �����ϴ�.");
                return;
            }
        }

        craftingItemList.Add(Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot]);

        InsertSlot();

        return;
    }

    public void onClickCraftingButton()
    {
        if (craftingItemList.Count < 1)
        {
            Debug.Log("�������� �ϳ� �̻� ��������.");
            return;
        }
        else
        {
 //           CheckCombination();
        }
    }

    public void InsertSlot()
    {
        if (craftingItemList.Count > 0)
        {
            craftingSlots[craftingItemList.Count - 1].Additem(Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot]);
        }
        return;
    }

    public void CheckItemAmount(int i)
    {
        if (craftingItemList[i].itemCount == Inventory.instance.inventoryItemList[i].itemCount)
        {
            Debug.Log("���� ���� �̻��� ���� �� �����ϴ�.");
        }
    }

    public void SlotItem()
    {
        if (craftingItemList.Count == 2)        // 2���� ���������� ������ �õ��ϴ� ���
        {
//            craftingItemList[0].itemCount == 
        }
    }

 /*
    public int CheckCombination()
    {
        if (craftingItemList.Count == 1)
        {
            for (int i = 0; i < craftingCombination.combinations.Count; i++)
            {
                if (craftingItemList[0].itemID == craftingCombination.combinations[i].firstID)
                {
                    Debug.Log(craftingCombination.combinations[i].outputID);
                    return craftingCombination.combinations[i].outputID;
                }
                else
                {
                    Debug.Log("�������� �ʴ� �����Դϴ�.");
                    return 0;
                }
            }
        }
        else if (craftingItemList.Count == 2)
        {
            for (int i = 0; i < craftingCombination.combinations.Count; i++)
            {
                if ((craftingItemList[0].itemID == craftingCombination.combinations[i].firstID ||
                    craftingItemList[0].itemID == craftingCombination.combinations[i].secondID) &&
                        (craftingItemList[1].itemID == craftingCombination.combinations[i].firstID ||
                        craftingItemList[1].itemID == craftingCombination.combinations[i].secondID)) {
                    Debug.Log(craftingCombination.combinations[i].outputID);
                    return craftingCombination.combinations[i].outputID;
                }
                else
                {
                    Debug.Log("�������� �ʴ� �����Դϴ�.");
                }
            }
        }
        else if (craftingItemList.Count == 3)
        {
            for (int i = 0; i < craftingCombination.combinations.Count; i++)
            {
 //             if ((����1||����2||����3)&&(����4||����5||����6)&&(����7||����8||����9))
            }
        }
    }
 */

    public void CraftItem()
    {

    }
}
