using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;
    private Movement3D movement3D;

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
    }


    private void Update()
    {
        //x, z 방향이동 
        float x = Input.GetAxisRaw("Horizontal"); //방향키 좌우 움직임
        float z = Input.GetAxisRaw("Vertical");  //방향키 위아래 움직임

        movement3D.MoveTo(new Vector3(x, 0, z));

        //점프키를 눌러 y축 방향으로 뛰어오르기
        if(Input.GetKeyDown(jumpKeyCode))
        {
            movement3D.jumpTo();
        }

    }
}
