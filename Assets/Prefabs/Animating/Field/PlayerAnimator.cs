using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject attackCollision;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnMovement(float horizontal, float vertical)
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);       
    }
    public void OnJump()
    {
        animator.SetTrigger("onJump");
    }
    public void OnWeaponAttack()
    {
        animator.SetTrigger("onWeaponAttack"); 
    }
    public void OnAttackCollision()
    {
        attackCollision.SetActive(true);
    }

    /*
    public enum eCharacterState
    {
        movement,
        attack,
        jump
    }
    public float MoveDuration(eCharacterState move)
    {
        string name = string.Empty;
        switch (move)
        {
            case eCharacterState.movement:
                name = "Movement";
                break;
            case eCharacterState.attack:
                name = "2Hand-Sword-Attack1";
                break;
            case eCharacterState.jump:
                name = "2Hand-Sword-Jump";
                break;

            default:
                return 0;
        }
        float time = 0;
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++) {
            if (ac.animationClips[i].name == name)
            {
                time = ac.animationClips[i].length;
            }
        }
        return time;
    }
    */
}
