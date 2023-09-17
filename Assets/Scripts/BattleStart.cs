using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision MonsterBattle)
    {
        if (MonsterBattle.collider.gameObject.CompareTag("Monster"))
        {

            /*
                        //Destroy(GameObject.Find("Main Camera")); 파괴말고 비활성화로
                        GameObject.Find("Main Camera").SetActive(false);

                        GameObject player = GameObject.FindGameObjectWithTag("Player");
                        player.transform.position = new Vector3(3f, 1f, -4.5f);
                        */

            GameObject.Find("Main Camera").SetActive(false);
            SceneManager.LoadScene("BattleScene", LoadSceneMode.Additive);


            /*
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            player.transform.position = new Vector3(3f, 1f, -4.5f);

            //player.GetComponent<BattleChar>().enabled = true;
            GameObject monster = GameObject.FindGameObjectWithTag("Monster");
            monster.transform.position = new Vector3(0f, 1f, 5f);
            monster.transform.localEulerAngles = new Vector3(0, 0, 0);
            */
            

        }
    }
}
