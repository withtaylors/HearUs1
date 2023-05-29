using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // E Ű�� ���� �������� ������

    private float interactionDistance = 2.0f; // ��ȣ�ۿ� ���� �ִ� �Ÿ�

    public int itemID;
    public int _count;

    private void OnTriggerStay(Collider collision)
    {
        float distance = Vector3.Distance(collision.transform.position, this.gameObject.transform.position); // �ݶ��̴��� ������Ʈ�� �Ÿ� ���

        if (distance < interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
                    {
                        Inventory.instance.GetAnItem(itemID, _count);

                        Destroy(this.gameObject);
                    }
        }
    }
}