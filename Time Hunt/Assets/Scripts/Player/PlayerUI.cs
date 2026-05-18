using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("Skills UI")]
    [SerializeField] private Image swordProgressImage;
    [SerializeField] private Image fireBallProgressImage;
    [SerializeField] private Image dashProgressImage;

    [Header("Powerups UI")]
    [SerializeField] private Image InvenciblePowerupProgress;
    [SerializeField] private Image SpeedPowerupProgress;
    [SerializeField] private Image Damage2XPowerupProgress;

    [SerializeField] private Slider lifeBarSlider;

    public void UpdateSwordProgress(float progress)
    {
        swordProgressImage.fillAmount = progress;
    }

    public void UpdateFireBallProgress(float progress)
    {
        fireBallProgressImage.fillAmount = progress;
    }

    public void UpdateDashProgress(float progress)
    {
        dashProgressImage.fillAmount = progress;
    }

    public void UpdateMaxHealth(int maxHealth, int currentHealth)
    {
        lifeBarSlider.maxValue = maxHealth;
        lifeBarSlider.value = currentHealth;
    }

    public void UpdateCurrentHealth(int modifyHealth, int currentHealth)
    {
        lifeBarSlider.value = currentHealth;
    }

    public void UpdatePowerupProgress(TypePowerup powerup, float progress)
    {
        progress = 1 - progress; // Inverte o progreeso para que a barra esvazie conforme o tempo passa

        switch (powerup)
        {
            case TypePowerup.INVENCIBLE:
                InvenciblePowerupProgress.fillAmount = progress;
                break;
            case TypePowerup.SPEED:
                SpeedPowerupProgress.fillAmount = progress;
                break;
            case TypePowerup.DAMAGE2X:
                Damage2XPowerupProgress.fillAmount = progress;
                break;
        }
    }

    public void ChangeVisibility(TypePowerup powerup, bool isVisible)
    {
        switch (powerup)
        {
            case TypePowerup.INVENCIBLE:
                InvenciblePowerupProgress.transform.parent.gameObject.SetActive(isVisible);
                break;
            case TypePowerup.SPEED:
                SpeedPowerupProgress.transform.parent.gameObject.SetActive(isVisible);
                break;
            case TypePowerup.DAMAGE2X:
                Damage2XPowerupProgress.transform.parent.gameObject.SetActive(isVisible);
                break;
        }
    }
}
