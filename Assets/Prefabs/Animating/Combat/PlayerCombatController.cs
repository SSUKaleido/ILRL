using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    public float moveSpeed = 0.01f; // 이동 속도
    public GameObject targetPosition; // 이동할 목표 위치
    public Vector3 oriPos; // 처음 오브젝트 위치
    private Animator animator; 
    public Boolean isAttack; // Attack 애니메이션 플래그
    public Boolean isDelay; // 코루틴용

    private void Start()
    {
        oriPos = gameObject.transform.position;
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {


        /* 공격 애니메이션 관련 함수 start */
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            isAttack = true;
            animator.SetTrigger("onAttack"); // Attack 애니메이션
        }
        if (isAttack)
        {
            Attack(); 
        }
        /* 공격 애니메이션 관련 함수 end */
    }


    /* 피격 애니메이션 */
    public void OnHit()
    {
        animator.SetTrigger("onHit");
    }

    /* 스턴 애니메이션 */
    public void OnStun()
    {
        animator.SetTrigger("onStunned");
    }

    /* 버프 애니메이션 */
    public void OnBuff()
    {
        animator.SetTrigger("onBuff");
    }

    /* 사망 애니메이션 */
    public void OnDeath()
    {
        animator.SetTrigger("Death");

    }

    /* 공격 애니메이션 관련 함수 Start */
    void Attack()
    {

        transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition.transform.position, moveSpeed);
        // 원래 위치 -> 상대 오브젝트 위치
        Invoke("ReturnHome", 1.3f); // 딜레이
    }
    void ReturnHome()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, oriPos, moveSpeed);
        // 상대 오브젝트 위치 -> 원래 위치
        isAttack = false; // Attack 상태 종료
    }
    /* 공격 애니메이션 관련 함수 End */
}
