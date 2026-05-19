using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [Header("UI Settings: ")]
    [SerializeField] private TMP_Text timeRemainingText;
    [SerializeField] private TMP_Text keysCollectedText;
    [SerializeField] private GameObject gameOverPanel;

    [Header("GameOver Settings: ")]
    [SerializeField] private TMP_Text timePlayedGameOverText;
    [SerializeField] private TMP_Text monstersDefeatedGameOverText;
    [SerializeField] private TMP_Text damageSufferedGameOverText;
    [SerializeField] private TMP_Text KeysCollectedGameOverText;
    [SerializeField] private TMP_Text scoreGameOverText;

    private int timeRemaining = 30;
    private int totalTimeOfMatch;

    private int monstersDefeated;
    private int damageSuffered;
    private int keysCollected;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeCount());
    }

    private IEnumerator TimeCount()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            timeRemaining--;
            totalTimeOfMatch++;

            timeRemainingText.text = timeRemaining + "s";
        }

        FinishMatch(false);
    }

    public void FinishMatch(bool victory)
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        timePlayedGameOverText.text = totalTimeOfMatch + "s";
        monstersDefeatedGameOverText.text = monstersDefeated.ToString();
        KeysCollectedGameOverText.text = keysCollected + "/3";
        damageSufferedGameOverText.text = damageSuffered.ToString();

        if (victory)
        {
            scoreGameOverText.text = "SCORE: " + Mathf.Max(0, CalculateScore());
        }
        else
        {
            scoreGameOverText.text = "SCORE: 0000";
        }
    }

    private int CalculateScore()
    {
        return ((2000 - totalTimeOfMatch) + monstersDefeated * 5 - damageSuffered * 2);
    }

    public void EnemyDefeated(int extraTime)
    {
        monstersDefeated++;
        timeRemaining += extraTime;
    }

    public void AddDamageSuffered(int damageReceived, int currentHealth)
    {
        damageSuffered += damageReceived;
    }

    public void KeyCollected()
    {
        keysCollected++;

        keysCollectedText.text = keysCollected + "/3";

        if (keysCollected >= 3)
        {
            FinishMatch(true);
        }
    }


}
