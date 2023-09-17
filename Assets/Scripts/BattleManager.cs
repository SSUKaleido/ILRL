using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{

    private PlayerAnimator playerAnimator;

    public static BattleManager instance;

    private bool battleActive;

    public GameObject battleScene;
    
        public Transform[] playerPositions;
        public Transform[] enemyPositions;
    
        public BattleChar[] playerPrefabs;
        public BattleChar[] enemyPrefabs;
    
    public List<BattleChar> activeBattlers = new List<BattleChar>();

    public int currentTurn;
    public bool turnWaiting;

    public GameObject uiButtonsHolder;

    public BattleMove[] movesList;
    public GameObject enemyAttackEffect;

    public DamageNumber theDamageNumber;

    public Text[] playerName, playerHP, PlayerMP;

    public int chanceToFlee = 100;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerAnimator = GetComponentInChildren<PlayerAnimator>();

    }

    void Awake()
    {
        /*
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        player.transform.position = new Vector3(0, 1, 0);
        
        
        GameObject monster = GameObject.FindGameObjectWithTag("Monster");
        monster.transform.position = new Vector3(0f, 1f, 5f);
        monster.transform.localEulerAngles = new Vector3(0, 0, 0);
        */

        //GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0,1,0);



        BattleStart(new string[] {  "Enemy"  });

    }


    // Update is called once per frame
    void Update()
    {
        //그냥 배틀씬 들어가는 코드
 /*       if(Input.GetKeyDown(KeyCode.T))
        {
            BattleStart(new string[] { "123123", "1212"});
        }
*/
 
        if(battleActive)
        {
            if(turnWaiting)
            {
                if(activeBattlers[currentTurn].isPlayer)
                {
                    uiButtonsHolder.SetActive(true);
                }
                else
                {
                    uiButtonsHolder.SetActive(false);

                    //enemy should attack
                    StartCoroutine(EnemyMoveCo());
                }

            }

            if(Input.GetKeyDown(KeyCode.N))
            {
                NextTurn();
            }
        }
    }
 
    public void BattleStart(string[] enemiesToSpawn)
    {
        if(!battleActive )
        {
            battleActive = true;

            GameManager.instance.battleActive = true;

            //battleScene.SetActive(true); 이렇게 전투씬들어왔을 때

            //AudioManager.instance.PlayBGM(0); BGM 바꿀 때 
            
            //turnWaiting = true;
            //currentTurn = Random.Range(0, activeBattlers.Count);
            


            // 캐릭터 새로 생성하는 과정임. 




            for (int i = 0; i< playerPositions.Length; i++)
            {
                if (GameManager.instance.playerStats[i].gameObject.activeInHierarchy)
                {
                    for(int j = 0; j < playerPrefabs.Length; j++)
                    {
                        if (playerPrefabs[j].charName == GameManager.instance.playerStats[i].charName)
                        {
                            BattleChar newPlayer = Instantiate(playerPrefabs[j], playerPositions[i].position, playerPositions[i].rotation);
                            newPlayer.transform.parent = playerPositions[i];
                            activeBattlers.Add(newPlayer);

                            CharStats thePlayer = GameManager.instance.playerStats[i];
                            activeBattlers[i].currentHP = thePlayer.currentHP;
                            activeBattlers[i].MaxHP = thePlayer.maxHP;
                            activeBattlers[i].MaxMP = thePlayer.maxMP;
                            activeBattlers[i].currentMP = thePlayer.currentMP;
                            activeBattlers[i].strength = thePlayer.strength;
                            activeBattlers[i].defence = thePlayer.defence;
                            activeBattlers[i].wpnPower = thePlayer.wpnPwr;
                            activeBattlers[i].armrPower = thePlayer.armrPwr;
                        }
                    }    
                }
            }
            for (int i = 0; i < enemiesToSpawn.Length; i++)
            {
                if (enemiesToSpawn[i] != "")
                {
                    for (int j = 0; j < enemyPrefabs.Length; j++)
                    {
                        if (enemyPrefabs[j].charName == enemiesToSpawn[i])
                        {
                            BattleChar newEnemy = Instantiate(enemyPrefabs[j], enemyPositions[i].position, enemyPositions[i].rotation);
                            newEnemy.transform.parent = enemyPositions[i];
                            activeBattlers.Add(newEnemy);
                        }

                    }
                }
            }

            turnWaiting = true;
            currentTurn = Random.Range(0, activeBattlers.Count);

            UpdateUIStats();

        }
    }
    
    public void NextTurn()
    {
        currentTurn++;
        if(currentTurn >= activeBattlers.Count)
        {
            currentTurn = 0;

        }
        turnWaiting = true;

        UpdateBattle();
        UpdateUIStats();
    }
    public void UpdateBattle()
    {
        bool allEnemiesDead = true;
        bool allPlayersDead = true;

        for(int i = 0; i< activeBattlers.Count; i++)
        {
            if (activeBattlers[i].currentHP < 0)
            {
                activeBattlers[i].currentHP = 0;
            }

            if (activeBattlers[i].currentHP == 0)
            {
                //Handle dead battler
            }
            else
            {
                if (activeBattlers[i].isPlayer)
                {
                    allPlayersDead = false;
                }
                else
                {
                    allEnemiesDead = false;
                }
            }
        }
        if(allEnemiesDead ||allPlayersDead)
        {
            if(allEnemiesDead)
            {
                //end battle in victory
            }
            else
            {
                //end battle in failure
            }

            //battleScene.SetActive(false);
            GameManager.instance.battleActive = false;
            battleActive = false;

        }
        else
        {
            while (activeBattlers[currentTurn].currentHP == 0)
            {
                currentTurn++;
                if(currentTurn >= activeBattlers.Count)
                {
                    currentTurn = 0;
                }
            }
        }
    }

    public IEnumerator EnemyMoveCo()
    {
        turnWaiting = false;
        yield return new WaitForSeconds(1f);
        EnemyAttack();
        yield return new WaitForSeconds(1f);
        NextTurn();
    }

    public void EnemyAttack()
    {
        List<int> players = new List<int>();
        for(int i = 0; i< activeBattlers.Count; i++)
        {
            if (activeBattlers[i].isPlayer && activeBattlers[i].currentHP >0)
            {
                players.Add(i);
            }
        }
        //int selectedTarget = players[Random.Range(0, players.Count)];
        int selectedTarget = 0;

        //activeBattlers[selectedTarget].currentHP -= 30;

        int selectAttack = Random.Range(0, activeBattlers[currentTurn].movesAvailable.Length);
        int movePower = 0;
        for(int i = 0; i< movesList.Length; i++)
        {
            if (movesList[i].moveName == activeBattlers[currentTurn].movesAvailable[selectAttack])
            {
                Instantiate(movesList[i].theEffect, activeBattlers[selectedTarget].transform.position, activeBattlers[selectedTarget].transform.rotation);
                movePower = movesList[i].movePower;
            }
        }

        Instantiate(enemyAttackEffect, activeBattlers[currentTurn].transform.position, activeBattlers[currentTurn].transform.rotation);

        DealDamage(selectedTarget, movePower);
    }

    public void DealDamage(int target, int movePower)
    {
        float atkPwr = activeBattlers[currentTurn].strength + activeBattlers[currentTurn].wpnPower;
        float defPwr = activeBattlers[target].defence + activeBattlers[target].armrPower;

        float damageCalc = (atkPwr / defPwr) * movePower * Random.Range(.9f, 1.1f);
        int damageToGive = Mathf.RoundToInt(damageCalc);

        Debug.Log(activeBattlers[currentTurn].charName + " is dealing " + damageCalc + "(" + damageToGive + " damage to " + activeBattlers[target].charName);

        activeBattlers[target].currentHP -= damageToGive;

        Instantiate(theDamageNumber, activeBattlers[target].transform.position, activeBattlers[target].transform.rotation).SetDamage(damageToGive);

        UpdateUIStats();
    }

    public void UpdateUIStats()
    {
        for(int i =0; i< playerName.Length; i++)
        {
            if(activeBattlers.Count > i)
            {
                if (activeBattlers[i].isPlayer)
                {
                    BattleChar playerData = activeBattlers[i];

                    playerName[i].gameObject.SetActive(true);
                    playerName[i].text = playerData.charName;
                    playerHP[i].text = Mathf.Clamp(playerData.currentHP, 0, int.MaxValue)  + "/" + playerData.MaxHP;
                    PlayerMP[i].text = Mathf.Clamp(playerData.currentMP, 0, int.MaxValue) + "/" + playerData.MaxMP;

                }
                else
                {
                    playerName[i].gameObject.SetActive(false);
                }
            }
            else
            {
                playerName[i].gameObject.SetActive(false);
            }
        }
    }

    public void PlayerAttack(string moveName/*, int selectedTarget*/)
    {
        int selectedTarget = 1;

        int movePower = 0;
        for (int i = 0; i < movesList.Length; i++)
        {
            if (movesList[i].moveName == moveName)
            {
                Instantiate(movesList[i].theEffect, activeBattlers[selectedTarget].transform.position, activeBattlers[selectedTarget].transform.rotation);
                movePower = movesList[i].movePower;
            }
        }

        playerAnimator.OnWeaponAttack();
        Instantiate(enemyAttackEffect, activeBattlers[currentTurn].transform.position, activeBattlers[currentTurn].transform.rotation);

        DealDamage(selectedTarget,movePower);

        uiButtonsHolder.SetActive(false);
        NextTurn();
    }


    public void Flee()
    {
        int fleeSuccess = Random.Range(0, 100);
        if(fleeSuccess < chanceToFlee)
        {
            //end the battle
            battleActive = false;
            //battleScene.SetActive(false); Scean 나가는 걸로

            GameObject.Find("Camera").SetActive(false);
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("SampleScene"));
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(true);

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<Movement3D>().enabled = true;


            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.UnloadSceneAsync("BattleScene");

            
            
            
            
        }
        else
        {
            //SceneManager.LoadScene("BattleScene");
        }

    }
}
