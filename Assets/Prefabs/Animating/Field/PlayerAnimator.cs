using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject attackCollision; // �浹 ���� (empty ������Ʈ)
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /* �̵� �ִϸ��̼� */
    public void OnMovement(float horizontal, float vertical)
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);       
    }

    /* ���� �ִϸ��̼� */
    public void OnJump()
    {
        animator.SetTrigger("onJump");
    }

    /*  ���� �ִϸ��̼� */
    public void OnWeaponAttack()
    {
        animator.SetTrigger("onWeaponAttack"); 
    }

    /* �浹 ���� */
    public void OnAttackCollision()
    {
        attackCollision.SetActive(true);
    }


}
