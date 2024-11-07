using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public Equip curEquip;
    public Transform equipParent; // 장비를 촬영할 카메라 위치

    private PlayerController controller;
    private PlayerCondition condition;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
    }

    // 새로운 장비를 장착할 함수(아이템 데이터를 매개변수로 가져온다)
    public void EquipNew(ItemData data)
    {
        // 기존 장착되어 있는 템은 Unequip 함수를 통해 해제함
        UnEquip();
        // 새로운 장착 아이템을 생성(itemdata에 있는 equipPrefab)하고 생성된 프리팹에 equip 컴포넌트가 있는지 확인후 curEquip 변수에 넣어줌.
        curEquip = Instantiate(data.equipPrefab, equipParent).GetComponent<Equip>();
    }

    // 장착 해제함수
    public void UnEquip()
    {
        // 현재 장착되어 있는 장비가 null이 아니라면
        if(curEquip != null)
        {
            // curEquip 게임오브젝트를 파괴하고 null 상태로 
            Destroy(curEquip.gameObject);
            curEquip = null;
        }
    }

    // 플레이어 공격 입력을 받는 함수
    public void OnAttackInput(InputAction.CallbackContext context)
    {
        // 입력이 활성화 중이면서 curEquip이 null이 아니고 controller가 시야각에 있을때
        if (context.phase == InputActionPhase.Performed && curEquip != null && controller.canLook)
        {

            curEquip.OnAttackInput();
        }
    }
}
