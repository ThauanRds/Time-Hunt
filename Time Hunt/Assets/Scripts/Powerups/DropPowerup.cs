using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPowerup : MonoBehaviour
{
    [SerializeField] private GameObject[] powerups;
    // Gera um slider no inspector para definir a chance de dropar um powerup, onde 0 é 0% e 1 é 100%
    [Range(0f,1f)] [SerializeField] private float dropChance;

    public void InstancePowerup()
    {
        float random = Random.Range(0f, 1f);

        if (random < dropChance)
        {
            Instantiate(powerups[Random.Range(0, powerups.Length)], transform.position, Quaternion.identity);
        }
    }
}
