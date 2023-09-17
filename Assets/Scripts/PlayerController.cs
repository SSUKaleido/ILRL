using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;
    private Movement3D movement3D;
    private static PlayerController instance;

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        /*
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        */
    }


    private void Update()
    {
        //x, z �����̵� 
        float x = Input.GetAxisRaw("Horizontal"); //����Ű �¿� ������
        float z = Input.GetAxisRaw("Vertical");  //����Ű ���Ʒ� ������

        movement3D.MoveTo(new Vector3(x, 0, z));

        //����Ű�� ���� y�� �������� �پ������
        if(Input.GetKeyDown(jumpKeyCode))
        {
            movement3D.jumpTo();
        }


    }
}
