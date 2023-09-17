using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private Animator animatior;
    private SkinnedMeshRenderer meshRenderer;
    private Color originColor;
    [SerializeField]
    public float colorTime = 0.5f;
    

    private void Awake()
    {
        animatior = GetComponent<Animator>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originColor = meshRenderer.material.color;
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

    /* 피격시 실행되는 이벤트 씬+ */
    public void TakeDamage()
    {
        Debug.Log("피격당했습니다.");
        animatior.SetTrigger("onHit");
        GoBattle();
        StartCoroutine("OnHitColor"); // 코루틴 실행
    }

    /* 피격시 Enemy 오브젝트의 색상을 변경하는 코루틴 함수*/
    private IEnumerator OnHitColor()
    {
        meshRenderer.material.color = Color.red; // Enemy 오브젝트의 색상 -> Red
        yield return new WaitForSeconds(colorTime); // red상태를 colorTimes만큼 유지함

        meshRenderer.material.color = originColor; //원래 mesh 색상으로 돌아감
    }


}
