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

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Movement3D>().enabled = false;

        SceneManager.LoadScene("BattleScene", LoadSceneMode.Additive);
    }

}