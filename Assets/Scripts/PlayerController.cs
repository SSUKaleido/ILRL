using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space; //Jump동작은 '스페이스 바'를 통해 트리거된다.
    [SerializeField]
    private Transform cameraTransform;
    private Movement3D movement3D;
    private PlayerAnimator playerAnimator;
    [SerializeField]
    public Boolean isDelay; //공격 딜레이 판별
    public float delayTime = 1.3f; //딜레이를 줄 시간
    


    private void Awake()
    {
        /* 게임 동작 화면에 마우스 커서를 보이지 않도록 설정 */
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        /* */
        movement3D = GetComponent<Movement3D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    private void Update()
    {
        /* 플레이어의 움직임 조작 */
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        playerAnimator.OnMovement(x, z);

        movement3D.MoveSpeed = z > 0 ? 5.0f : 2.0f;
        movement3D.MoveTo(cameraTransform.rotation * new Vector3(x, 0, z));

        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

        /* jumpKeyCode가 입력된다면? */
        if (Input.GetKeyDown(jumpKeyCode))
        {
            playerAnimator.OnJump(); // Jump 애니메이션
            movement3D.jumpTo(); // 실제 Jump 동작
        }

        /* 마우스 왼쪽 클릭이 입력된다면? */
        if (Input.GetMouseButtonDown(0)) {
            if (!isDelay) //딜레이가 없을 경우
            {
                isDelay = true; // 딜레이 예약 걸기
                Debug.Log("Attack"); // Debug
                playerAnimator.OnWeaponAttack(); // Attack 애니메이션
                StartCoroutine(CountAttackDelay()); // 코루틴 시작              
            }
            else
            {
                Debug.Log("Delay"); //Delay가 되고있는 상황일 경우 Debug 로그 출력
            }
        }
    }

    /* CountAttackDelay : 딜레이를 주는 코루틴 함수 */
    IEnumerator CountAttackDelay()
    {   
        yield return new WaitForSeconds(delayTime); //delayTime 만큼 유예를 준다.
        isDelay = false;
    }
}
