using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private ItemDatabase theDatabase;       // ������ �����ͺ��̽� ��ü

    private List<InventorySlot> slots;      // �κ��丮 ���Ե�
    public Transform tf;                    // ���Ե��� �θ� ��ü (GridSlot)

    private ItemDescription itemDes;
    public Transform tf_itemDes;

    private List<Item> inventoryItemList;   // �÷��̾ ������ ������ ����Ʈ

    public GameObject slotPrefab;           // ���� ���� ������ ���� ���� ������ �ҷ�����
    public GameObject go_Inventory;         // �κ��丮 Ȱ��ȭ/��Ȱ��ȭ�� ���� GameObject �ҷ�����
    public GameObject go_itemDes;           // ���� �г� Ȱ��ȭ/��Ȱ��ȭ�� ���� GameObject �ҷ�����
    public GameObject go_SelectedImage;     // ���õ� �����̶�� ���� ��Ÿ���� �̹��� �ҷ�����

    public int selectedSlot;                // ���õ� ���� -> �⺻�� 0

    private bool activated;                 // �κ��丮 Ȱ��ȭ �� true
    private bool stopKeyInput;              // Ű �Է� ���� (�Һ��� ��, ������ �� �˾� �޽��� �߸� Ű �Է� ����)

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    private void Awake()
    {
        // �̱���
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);  // �� ��ȯ �ÿ��� ����
    }

    void Start()
    {
        theDatabase = FindObjectOfType<ItemDatabase>();                 // ������ �����ͺ��̽� ������Ʈ
        inventoryItemList = new List<Item>();                           // �κ��丮 ������ ����Ʈ
        slots = new List<InventorySlot>(tf.GetComponentsInChildren<InventorySlot>());
        itemDes = tf_itemDes.GetComponentInChildren<ItemDescription>();
        selectedSlot = 0;
    }

    void Update()
    {
        if (!stopKeyInput)
        {
            if (Input.GetKeyDown(KeyCode.I)) // �κ��丮 Ȱ��ȭ
            {
                activated = !activated;
                if (activated)
                {
                    go_Inventory.SetActive(true);
                }
                else
                {
                    go_Inventory.SetActive(false);
                }
            }
            if (activated)
            {
                if (inventoryItemList.Count > 0) // �κ��丮 ������ ����Ʈ�� ����� ��Ұ� ���� ��쿡�� ����
                {
                    go_SelectedImage.SetActive(true);
                    go_itemDes.SetActive(true);
                    TryInputArrowKey();
                    SelectedItemDes(inventoryItemList[selectedSlot].itemID);
                }
                else
                {
                    go_SelectedImage.SetActive(false);
                    go_itemDes.SetActive(false);
                }
            }
        }
    }
    public void GetAnItem(int _itemID, int _count = 1)              // �κ��丮 ����Ʈ�� ������ �߰�
    {
        for (int i = 0; i < theDatabase.itemList.Count; i++)        // �����ͺ��̽� ������ �˻�
        {
            if (_itemID == theDatabase.itemList[i].itemID)          // �����ͺ��̽� ������ �߰�
            {
                for (int j = 0; j < inventoryItemList.Count; j++)   // ����ǰ �� ���� �������� �ִ��� �˻�
                {
                    if (inventoryItemList[j].itemID == _itemID)     // ���� �������� �ִٸ� ������ ����
                    {
                        // inventoryItemList[j].itemCount += _count;
                        slots[j].setItemCount(inventoryItemList[j]);
                        return;
                    }

                }
                inventoryItemList.Add(theDatabase.itemList[i]);     // ���ٸ� ����ǰ�� �ش� ������ �߰�
                CreateSlot();
                slots[slots.Count - 1].Additem(theDatabase.itemList[i]);
                return;
            }
        }
        Debug.LogError("�����ͺ��̽��� �ش� ID ���� ���� �������� �������� �ʽ��ϴ�.");
    }
    public void CreateSlot()        // ���ο� �������� ��� ���ο� ���� ����
    {
        InventorySlot slot = Instantiate(slotPrefab, tf).GetComponent<InventorySlot>();
        slots.Add(slot);
        
        Button button = slot.GetComponentInChildren<Button>();
        SlotButton slotButton = button.GetComponentInChildren<SlotButton>();
        slotButton.slotIndex = slots.Count - 1; // ���� �ε��� ����
    }
    private void SelectedSlot()     // ������ ���õǾ����� ��Ÿ���� �̹���(�׵θ�) ��ġ �̵�
    {
        go_SelectedImage.transform.position = slots[selectedSlot].transform.position;
    }
    private void TryInputArrowKey() // Ű����� ���õ� ���� ����
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeSlotLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeSlotRight();
        }
        SelectedSlot();
    }
    private void ChangeSlotLeft()   // ���� �������� �̵� (�κ��丮 ������ ����Ʈ�� ���� �������� �۵�)
    {
            if (selectedSlot == 0)
                selectedSlot = inventoryItemList.Count - 1;
            else
                selectedSlot--;
    }
    private void ChangeSlotRight()  // ������ �������� �̵� (�κ��丮 ������ ����Ʈ�� ���� �������� �۵�)
    {
            if (selectedSlot == inventoryItemList.Count - 1)
                selectedSlot = 0;
            else
                selectedSlot++;
    }
    private void SelectedItemDes(int _itemID)                   // ���õ� �������� ������ ���� ��
    {
        for (int i = 0; i < inventoryItemList.Count; i++)
        {
            if (inventoryItemList[i].itemID == _itemID)
            {
                itemDes.DisplayDes(inventoryItemList[i]);
                break;
            }
        }
    }
    public void DeleteItem()        // ������ ����
    {
        int temp = selectedSlot;          // selectedSlot �ӽ� ����

        inventoryItemList.RemoveAt(temp);
        Destroy(slots[temp].gameObject);
        slots.RemoveAt(temp);

        if (selectedSlot >= inventoryItemList.Count)
        {
            selectedSlot = inventoryItemList.Count - 1;
        }
        
        if (selectedSlot < 0 && inventoryItemList.Count > 0)
        {
            selectedSlot = 0;
        }

        if (inventoryItemList.Count == 0) // �κ��丮�� ��� ������ �Լ� ��� ����
            return;

        SelectedSlot();
    }

}
