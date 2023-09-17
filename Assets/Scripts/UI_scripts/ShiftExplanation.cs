using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftExplanation : MonoBehaviour
{


    [SerializeField]
    private GameObject go_shift;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {

            go_shift.SetActive(false);

        }



    }
}
