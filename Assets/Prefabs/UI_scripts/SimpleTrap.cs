using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrap : MonoBehaviour
{



    [SerializeField]
    private GameObject touch;

    [SerializeField]
    private int damage;

    private bool isActivated = false;   // true가 되면 가동 x


    // Start is called before the first frame update
    void Start()
    {


        
    }

    private void OnTriggerEnter(Collider other)
    {

            if (!isActivated)
            {

                if(other.transform.tag != "Untagged")
                {

                    isActivated = true;

                    if (other.transform.name == "Player")
                    {

                        other.transform.GetComponent<StatusController>().DecreaseHP(damage);

                    }

                }

            }

    }

    private void OnTriggerExit(Collider other)
    {

        if (isActivated)
        {

            isActivated = false;

        }

    }

}
