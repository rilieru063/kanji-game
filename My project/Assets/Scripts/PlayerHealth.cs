using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int currentHP;

    public int CurrentHP => currentHP;
    public int MaxHP => maxHP;

    public event Action<int, int> OnHPChanged;

    void Start()
    {
        currentHP = maxHP;
        OnHPChanged?.Invoke(currentHP, maxHP);
    }

    public void TakeDamage(int damage)
    {
        currentHP = Mathf.Max(currentHP - damage, 0);
        OnHPChanged?.Invoke(currentHP, maxHP);

        Debug.Log("HP：" + currentHP);

        if (currentHP <= 0)
        {
            Debug.Log("ゲームオーバー！");
        }
    }

    public void Heal(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);
        OnHPChanged?.Invoke(currentHP, maxHP);

        Debug.Log("HP：" + currentHP);
    }
    [ContextMenu("Test/Damage")]
    private void TestTakeDamage()
    {
        TakeDamage(30);
    }
    [ContextMenu("Test/Heal")]
    private void TestTakeHeal()
    {
        Heal(20);
    }
}