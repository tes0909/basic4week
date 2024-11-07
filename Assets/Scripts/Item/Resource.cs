using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    
    public ItemData itemToGive; // 아이템 드롭 데이터를 ItemData에서 가져온다.
    public int quantityPerHit = 1; // 1번 때릴때 몇개의 아이템이 드롭되는가
    public int capacity; // 총 때릴 수 있는 횟수
   
    // Gather 함수(매개변수로 ray와 충돌한 hitpoint, 충돌한 면의 수직인 법선벡터를 가져옴)
    public void Gather(Vector3 hitPoint, Vector3 hitNormal)
    {
        for (int i = 0; i < quantityPerHit; i++)
        {
            if (capacity <= 0) break;
            capacity -= 1;
            Instantiate(itemToGive.dropPrefab, hitPoint + Vector3.up, Quaternion.LookRotation(hitNormal, Vector3.up));
        }
    }
}
