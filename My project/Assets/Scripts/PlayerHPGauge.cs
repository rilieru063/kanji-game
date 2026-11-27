
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPGauge : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image hpFill;

    private void Start()
    {
        // Å‰‚ÌHP‚ğƒQ[ƒW‚É”½‰f
        UpdateGauge(playerHealth.CurrentHP, playerHealth.MaxHP);

        // HP‚ª•Ï‰»‚µ‚½‚Æ‚«‚É’Ê’m‚ğó‚¯æ‚é
        playerHealth.OnHPChanged += UpdateGauge;
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHPChanged -= UpdateGauge;
        }
    }

    private void UpdateGauge(int currentHP, int maxHP)
    {
        hpFill.fillAmount = (float)currentHP / maxHP;
    }
}
