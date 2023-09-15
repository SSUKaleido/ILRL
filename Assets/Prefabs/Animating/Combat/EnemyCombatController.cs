using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatController : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    public GameObject targetPosition;
    public Vector3 oriPos;
    private Animator animator;
    public Boolean isAttack; 
    public Boolean isDelay; 

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
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            animator.SetTrigger("onHit");

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetTrigger("onStunned");

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetTrigger("onBuff");

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.SetTrigger("Death");

        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            animator.SetTrigger("onCastSpell");

        }



        /* 공격 애니메이션 관련 함수 */
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            isAttack = true;
            animator.SetTrigger("onAttack"); // Attack 애니메이션
        }
        if (isAttack)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition.transform.position, moveSpeed);
            Attack();
        }
    }

    void Attack()
    {
        
        Debug.Log("처음위치 : " + oriPos);
        transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition.transform.position, moveSpeed);
        Debug.Log("이동위치 : " + gameObject.transform.position);
        Invoke("ReturnHome", 1.3f);
    }
    void ReturnHome()
    {
        Debug.Log("돌아갈위치 : " + oriPos);
        transform.position = Vector3.Lerp(gameObject.transform.position, oriPos, moveSpeed);
        isAttack = false;
    }
}
