using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject go_BaseUi;
    private bool isPause = false;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            /*if (!GameManager.isPause)   pause인지 아닌지 알려주는 bool(아직 없음)
                CallMenu();
            else
                CloseMenu();
            */

            if (!isPause)
            {

                go_BaseUi.SetActive(true);
                isPause = true;
                CallMenu();

            }


            else
            {

                go_BaseUi.SetActive(false);
                isPause = false;
                CloseMenu();

            }
                

        }

    }

    private void CallMenu()
    {

        // GameManager.isPause = true;
        // go_BaseUi.SetActive(true);
        Time.timeScale = 0f;

    }

    private void CloseMenu()
    {

        // GameManager.isPause = false;
        // go_BaseUi.SetActive(false);
        Time.timeScale = 1f;

    }

    public void ClickSave()
    {

        Debug.Log("세이브");

    }

    public void ClickLoad()
    {

        Debug.Log("로드");

    }

        public void ClickExit()
    {

        Debug.Log("게임 종료");
        Application.Quit();

    }

}
