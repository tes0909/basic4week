using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EquipTool : Equip
{
    public float attackRate;
    private bool attacking;
    public float attackDistance;
    public float useStamina;

    [Header("Resource Gathering")]
    public bool doesGatherResources;

    [Header("Combat")]
    public bool doesDealDamage;
    public int damage;

    private Animator animator;
    private Camera camera;
    void Start()
    {
        animator = GetComponent<Animator>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnAttackInput()
    {
        // 공격중이지 않을때
        if (!attacking)
        {
            // usestamina 함수에 접근(useStamina 값을 매개변수로 받는다)
            if (CharacterManager.Instance.Player.condition.UseStamina(useStamina))
            {
                // 공격을 활성화(TRUE)로 만들고
                attacking = true;
                // 애니메이터 파라미터에 등록된 Attack 동작
                animator.SetTrigger("Attack");
                Invoke("OnCanAttack", attackRate);
            }
        }
    }

    void OnCanAttack()
    {
        attacking = false;
    }

    public void OnHit()
    {
        // 카메라 기준(너비 절반, 높이 절반)에 해당되는 부분에 ray를 쏴준다.
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        // ray를 쏴 attackDistance에 해당하는 충돌체 hit 반환
        if (Physics.Raycast(ray, out hit, attackDistance))
        {
            // 자원채취를 하면서, ray에 충돌한 collider 정보(resource 컴포넌트)를 찾는다.
            if (doesGatherResources && hit.collider.TryGetComponent(out Resource resource))
            {
                resource.Gather(hit.point, hit.normal);
            }
        }
    }
}
