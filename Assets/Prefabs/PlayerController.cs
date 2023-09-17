using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;
    private Movement3D movement3D;
    private StatusController theStatusController;

    void start()
    {

        theStatusController = FindObjectOfType<StatusController>();

    }

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
    }


    private void Update()
    {
   
        float x = Input.GetAxisRaw("Horizontal"); 
        float z = Input.GetAxisRaw("Vertical"); 

        movement3D.MoveTo(new Vector3(x, 0, z));

        if (Input.GetKeyDown(jumpKeyCode))
        {
            movement3D.jumpTo();
        }

    }
}
