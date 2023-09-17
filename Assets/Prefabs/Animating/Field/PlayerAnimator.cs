using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject attackCollision; // 충돌 범위 (empty 오브젝트)
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /* 이동 애니메이션 */
    public void OnMovement(float horizontal, float vertical)
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);       
    }

    /* 점프 애니메이션 */
    public void OnJump()
    {
        animator.SetTrigger("onJump");
    }

    /*  공격 애니메이션 */
    public void OnWeaponAttack()
    {
        animator.SetTrigger("onWeaponAttack"); 
    }

    /* 충돌 감지 */
    public void OnAttackCollision()
    {
        attackCollision.SetActive(true);
    }


}
