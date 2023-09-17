using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f; // 이동 속도

    [SerializeField]
    private float gravity = -9.81f; 

    [SerializeField]
    private float jumpForce = 3.0f; 
    private Vector3 moveDirection; // 이동 방향

    [SerializeField]
    private Transform cameraTransform;
    private CharacterController characterController;

    private void Awake()
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
        //moveDirection = new Vector3(direction.X, moveDirection.y, direction.z);
        Vector3 movedis = cameraTransform.rotation * direction;
        moveDirection = new Vector3(movedis.x, moveDirection.y, movedis.z);
    }

    public void jumpTo()
    {
        if(characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }
}
