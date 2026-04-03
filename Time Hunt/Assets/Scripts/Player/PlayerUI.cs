using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image swordProgressImage;
    [SerializeField] private Image fireBallProgressImage;
    [SerializeField] private Image dashProgressImage;

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
}
