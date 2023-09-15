using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    public GameObject targetPosition;
    public float Speed = 0.1f;

    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
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
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            animator.SetTrigger("onCastSpell");

        }
        */
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            animator.SetTrigger("onAttack");
            transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position, Speed);
            //Attack();
        }
    }


    public void Attack()
    {
        animator.SetTrigger("onAttack");
        transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position, Speed);




        /*
        Vector3 vTargetPos = target.transform.position;
        Vector3 vPos = this.transform.position;
        Vector3 vDist = vTargetPos - vPos;
        Vector3 vDir = vDist.normalized;
        float fDist = vDist.magnitude;
        if (fDist < Speed * Time.deltaTime)
        {
            transform.position += vDir * Speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(gameObject.transform.position, vTargetPos, Speed);
        }*/


        /*
        Vector3 oriPos = this.transform.position;
        target = GameObject.FindGameObjectWithTag("Player");
        Vector3 targetPos = target.transform.position;
        Debug.Log(oriPos);
        Debug.Log(targetPos);
        Vector3 distance = targetPos - oriPos;
        Debug.Log(distance);
        Vector3 direction = distance.normalized;
        float fDistance = distance.magnitude;

        transform.position += direction * Speed * Time.deltaTime;
        */
    }

}
