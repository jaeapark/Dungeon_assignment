using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;

    public ItemData itemData;
    public Action addItem;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();

        addItem += UseItem; 
    }

    private void UseItem()
    {
        if (itemData == null)
            return;

        if (itemData.type == itemType.GameEnd)
        {
            Debug.Log("빨간사과 획득! 게임 종료");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            return;
        }

        StartCoroutine(UseItemRoutine(itemData));

        itemData = null;
    }

    private IEnumerator UseItemRoutine(ItemData data)
    {
        Debug.Log("아이템 사용하는 중...");
        yield return new WaitForSeconds(1f);

        foreach (var c in data.consumables)
        {
            if (c.type == ConsumableType.Hunger)
            {
                condition.Eat(c.value);
                Debug.Log($"{data.displayName} 소비하고 허기를 {c.value} 회복했다");
            }
        }

        Debug.Log("아이템 사용 완료!");
    }

}
