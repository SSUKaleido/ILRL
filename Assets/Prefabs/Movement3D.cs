using UnityEngine;
public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5; //이동속도
    [SerializeField]
    private float gravity = -9.87f; //중력계수 
    [SerializeField]
    private float jumpForce = 3.0f; //뛰어오르는 힘
    private Vector3 moveDirection;  //이동 방향

    private CharacterController characterController;

    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Clamp(value, 2.0f, 5.0f);
    }

    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
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

}
