using System.Collections;
using UnityEngine;

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

    /* �ǰݽ� ����Ǵ� �̺�Ʈ ��+ */
    public void TakeDamage()
    {
        Debug.Log("�ǰݴ��߽��ϴ�.");
        animatior.SetTrigger("onHit");
        StartCoroutine("OnHitColor"); // �ڷ�ƾ ����
    }

    /* �ǰݽ� Enemy ������Ʈ�� ������ �����ϴ� �ڷ�ƾ �Լ�*/
    private IEnumerator OnHitColor()
    {
        meshRenderer.material.color = Color.red; // Enemy ������Ʈ�� ���� -> Red
        yield return new WaitForSeconds(colorTime); // red���¸� colorTimes��ŭ ������

        meshRenderer.material.color = originColor; //���� mesh �������� ���ư�
    }


}
