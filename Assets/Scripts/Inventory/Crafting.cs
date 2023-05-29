using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    private List<InventorySlot> craftingSlots;
    public Transform tf_craftingSlots;

    public List<Item> craftingItemList;

    public CraftingCombination craftingCombination; // 크래프팅 조합 객체

    private void Start()
    {
        craftingSlots = new List<InventorySlot>(tf_craftingSlots.GetComponentsInChildren<InventorySlot>());
        craftingItemList = new List<Item>();
    }

    public void onCiickSelectButton()
    {
        if (craftingItemList.Count > 0)
        {
            for (int i = 0; i < craftingItemList.Count; i++) // 크래프팅 아이템 리스트에 동일한 아이템이 있는지 검사
            {
                CheckItemAmount(i);

                if (craftingItemList[i].itemID == Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot].itemID)
                {
                    craftingItemList[i].itemCount += 1;
                    return;
                }
            }
        if (craftingItemList.Count == 3)                     // 슬롯이 전부 다 찬 경우
            {
                Debug.Log("빈 슬롯이 없습니다.");
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
            Debug.Log("아이템을 하나 이상 담으세요.");
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
            Debug.Log("보유 수량 이상을 담을 수 없습니다.");
        }
    }

    public void SlotItem()
    {
        if (craftingItemList.Count == 2)        // 2개의 아이템으로 조합을 시도하는 경우
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
                    Debug.Log("존재하지 않는 조합입니다.");
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
                    Debug.Log("존재하지 않는 조합입니다.");
                }
            }
        }
        else if (craftingItemList.Count == 3)
        {
            for (int i = 0; i < craftingCombination.combinations.Count; i++)
            {
 //             if ((조건1||조건2||조건3)&&(조건4||조건5||조건6)&&(조건7||조건8||조건9))
            }
        }
    }
 */

    public void CraftItem()
    {

    }
}
