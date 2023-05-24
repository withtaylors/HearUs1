using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{    
    // ������ �����ͺ��̽�
    public static ItemDatabase instance;

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

    public List<Item> itemList = new List<Item>();
    void Start()
    {
        itemList.Add(new Item(100, "����", "�׳� ���ڴ�.", Item.ItemType.�Ҹ�ǰ));
        itemList.Add(new Item(101, "��Ű", "���� ���� ��Ű �ʸ� ���� ������ but you know that it ain't for free, yeah ���� ���� ��Ű �ʹ� �ε巯��� (what?) �ڲٸ� �������� (ayy)", Item.ItemType.�Ҹ�ǰ));
    } 
}