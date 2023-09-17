using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CharStats[] playerStats;

    public bool battleActive;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            GoBattle();
        }
    }

    public void GoBattle()
    {
        GameObject.Find("Main Camera").SetActive(false);
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Additive);
    }

}