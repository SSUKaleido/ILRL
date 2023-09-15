using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatController : MonoBehaviour
{
    public float moveSpeed = 0.01f; // �̵� �ӵ�
    public GameObject targetPosition; // �̵��� ��ǥ ��ġ
    public Vector3 oriPos; // ó�� ������Ʈ ��ġ
    private Animator animator;
    public Boolean isAttack; // Attack �ִϸ��̼� üũ
    public Boolean isDelay; // �ڷ�ƾ��

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

        if (Input.GetKeyDown(KeyCode.Alpha5)) // ��� ����
        {
            OnHit(); // �ǰ� �ִϸ��̼�

        }
        

        /* ���� �ִϸ��̼� ���� �Լ� start */
        if (Input.GetKeyUp(KeyCode.Alpha1)) 
        {
            isAttack = true;
            animator.SetTrigger("onAttack"); // Attack �ִϸ��̼�
        }
        if (isAttack)
        {
            Attack();
        }
        /* ���� �ִϸ��̼� ���� �Լ� end */

    }

    /* �ǰ� �ִϸ��̼� */
    public void OnHit()
    {
        animator.SetTrigger("onHit");
    }

    /* ���� �ִϸ��̼� */
    public void OnStun(){
        animator.SetTrigger("onStunned");
    }

    /* ���� �ִϸ��̼� */
    public void OnBuff()
    {
        animator.SetTrigger("onBuff");
    }

    /* ��� �ִϸ��̼� */
    public void OnDeath()
    {
        animator.SetTrigger("Death");

    }

    /* ���� �ִϸ��̼� */
    public void OnSpell()
    {
        animator.SetTrigger("onCastSpell");
    }

    /* ���� �ִϸ��̼� ���� �Լ� Start */
    public void Attack()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition.transform.position, moveSpeed);
        // ���� ��ġ -> ��� ������Ʈ ��ġ
        Invoke("ReturnHome", 1.3f); // ������
    }
    public void ReturnHome()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, oriPos, moveSpeed);
        // ��� ������Ʈ ��ġ -> ���� ��ġ
        isAttack = false; // Attack ���� ����
    }
    /* ���� �ִϸ��̼� ���� �Լ� End */

}
