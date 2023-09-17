using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class StatusController : MonoBehaviour
{

    // 체력
    [SerializeField]    // 인스펙터 창에서 수정할 수 있게
    private int hp; // 최대 체력
    private int currentHp;  // 현재 체력

    // 체력 증가량
    [SerializeField]
    private int hpIncreaseSpeed;

    // 체력 닳고 바로 증가하는 게 아니기 때문에 재회복 딜레이
    [SerializeField]
    private int hpRechargeTime;
    private int currentHpRechargeTime;

    // 체력, 마나가 닳았는지 여부.
    private bool hpUsed;    // true = 닳았다. false = 안 닳았다.
    private bool mpUsed;

    // 마나
    [SerializeField]
    private int mp; // 최대 마나
    private int currentMp;  // 현재 마나

    // 필요한 이미지
    [SerializeField]
    private Image[] images_gauge;

    private const int HP = 0, MP = 1;

    // Start is called before the first frame update
    void Start()
    {

        currentHp = hp;
        currentMp = mp;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        HPRechargeTime();
        HPRecover();
        GaugeUpdate();

    }

    private void HPRechargeTime()   // 체력이 닳았으면 딜레이 줌
    {

        if (hpUsed)
        {

            if (currentHpRechargeTime < hpRechargeTime)
                currentHpRechargeTime++;
            
            else
                hpUsed = false;

        }

    }

    private void HPRecover()    // 체력이 안 닳았고 풀피가 아닐 때 설정한 증가량만큼 체력 자동 회복.
    {

        if ((!hpUsed) && (currentHp < hp))
        {

            currentHp += hpIncreaseSpeed;

        }

    }

    private void GaugeUpdate()  // 실제 화면 속 체력바 업데이트(이미지)
    {

        images_gauge[HP].fillAmount = (float)currentHp / hp;
        images_gauge[MP].fillAmount = (float)currentMp / mp;

    }

    public void IncreaseHP(int _count)  // 체력 회복. 풀피가 아닌데 count만큼 더할 수 있으면 더하고 넘어버리면 hp
    {

        if (currentHp + _count < hp)
            currentHp += _count;

        else
            currentHp = hp;

    }

    public void DecreaseHP(int _count)
    {

        hpUsed = true;
        currentHpRechargeTime = 0;

        if (currentHp - _count > 0)
            currentHp -= _count;

        else 
            currentHp = 0;

    }

    public int GetCurrentHP()
    {
       
        return currentHp;

    }

    // currentHp를 리턴하는 함수를 통해, 현재 체력이 0일 때 사망하는 코드를 간단히 생각해볼 수 있음

}
