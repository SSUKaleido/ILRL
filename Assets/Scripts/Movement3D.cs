
using UnityEngine;
public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 100; //�̵��ӵ�

    [SerializeField]
    private float runSpeed;
    public float applySpeed;
    [SerializeField]
    private float gravity = -9.87f; //�߷°�� 
    [SerializeField]
    private float jumpForce = 3.0f; //�پ������ ��
    private Vector3 moveDirection;  //�̵� ����

    private bool isRun = false; // 기본값 false

    private CharacterController characterController;

    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Clamp(value, 2.0f, 100.0f);
    }
    

   

    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
        applySpeed = moveSpeed;
    }

    private void Update()
    {
        if (characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

        TryRun();


        characterController.Move(moveDirection * applySpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {

        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);


    }

    public void jumpTo()
    {

        if (characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }

        private void TryRun()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {

            Running();

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            RunningCancel();

        }

    }

    private void Running()
    {

        isRun = true;
        applySpeed = runSpeed;

    }

    private void RunningCancel()
    {

        isRun = false;
        applySpeed = moveSpeed;

    }

}
