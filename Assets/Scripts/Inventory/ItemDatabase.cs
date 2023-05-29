using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{    
    // 아이템 데이터베이스
    public static ItemDatabase instance;

    private void Awake()
    {
        // 싱글톤
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);  // 씬 전환 시에도 유지
    }

    public List<Item> itemList = new List<Item>();
    void Start()
    {
        itemList.Add(new Item(100, "상자", "그냥 상자다.", Item.ItemType.소모품));
        itemList.Add(new Item(101, "질긴 덩굴", "질긴 덩굴. 잘라내기는 어렵지만 그만큼 질기고 잘 끊어지지 않는다.", Item.ItemType.재료));
        itemList.Add(new Item(102, "밧줄", "밧줄이다.", Item.ItemType.소모품));
    } 
}