using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;
    public Condition hunger;

    private void Start()
    {
        StartCoroutine(TryRegister());
    }

    private System.Collections.IEnumerator TryRegister()
    {
        // Player가 준비될 때까지 기다림
        while (CharacterManager.Instance.Player == null)
            yield return null;

        CharacterManager.Instance.Player.condition.uiCondition = this;
    }
}
