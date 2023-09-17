using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEffect
{

    public string itemName; // 아이템 이름 (키값으로 사용)
    public string[] part; // 부위. 뭘 회복할 건지 
    public int[] num; // 수치.

}

public class ItemEffectDataBAse : MonoBehaviour
{

    [SerializeField]
    private ItemEffect[] itemEffects;

    private StatusController thePlayerStatus;

    private const string HP = "HP", MP = "MP";

/*
    public void UseItem(Item _item)
    {

        if (_item.itemType == Item.ItemType.Used)
        {

            for (int x = 0; x < length; x++)
            {

                if (itemEffects[x].itemName == _item.itemName)
                {

                    for (int y = 0; y < itemEffects[x].part.length; y++)
                    {

                        switch(itemEffects[x].part[y])
                        {

                            case HP:
                                thePlayerStatus.IncreaseHP(itemEffects[x].num[y]);
                                break;

                            case MP:
                                thePlayerStatus.IncreaseMP(itemEffects[x].num[y]);
                                break;

                            default:
                                Debug.log("잘못된 Status 부위. HP, MP만 가능합니다.");

                        }

                    }

                    return;

                }   

            }

            Debug.log("ItemEffectDataBase에 일치하는 ItemName이 없습니다.");

        }

    }
*/
}


