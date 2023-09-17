
using System;
using System.Collections;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]

    private KeyCode jumpKeyCode = KeyCode.Space; //Jump������ '�����̽� ��'�� ���� Ʈ���ŵȴ�.
    [SerializeField]
    private Transform cameraTransform;
    private Movement3D movement3D;
    private PlayerAnimator playerAnimator;
    [SerializeField]
    public Boolean isDelay; //���� ������ �Ǻ�
    public float delayTime = 1.3f; //�����̸� �� �ð�
    


    private void Awake()
    {
        /* ���� ���� ȭ�鿡 ���콺 Ŀ���� ������ �ʵ��� ���� */
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        /* */
        movement3D = GetComponent<Movement3D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    private void Update()
    {
        /* �÷��̾��� ������ ���� */
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        playerAnimator.OnMovement(x, z);

        movement3D.MoveSpeed = z > 0 ? 5.0f : 2.0f;
        movement3D.MoveTo(cameraTransform.rotation * new Vector3(x, 0, z));

        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

        /* jumpKeyCode�� �Էµȴٸ�? */
        if (Input.GetKeyDown(jumpKeyCode))
        {
            playerAnimator.OnJump(); // Jump �ִϸ��̼�
            movement3D.jumpTo(); // ���� Jump ����
        }

        /* ���콺 ���� Ŭ���� �Էµȴٸ�? */
        if (Input.GetMouseButtonDown(0)) {
            if (!isDelay) //�����̰� ���� ���
            {
                isDelay = true; // ������ ���� �ɱ�
                Debug.Log("Attack"); // Debug
                playerAnimator.OnWeaponAttack(); // Attack �ִϸ��̼�
                StartCoroutine(CountAttackDelay()); // �ڷ�ƾ ����              
            }
            else
            {
                Debug.Log("Delay"); //Delay�� �ǰ��ִ� ��Ȳ�� ��� Debug �α� ���
            }
        }
    }

    /* CountAttackDelay : �����̸� �ִ� �ڷ�ƾ �Լ� */
    IEnumerator CountAttackDelay()
    {   
        yield return new WaitForSeconds(delayTime); //delayTime ��ŭ ������ �ش�.
        isDelay = false;

    }
}
