using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private string targetTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            targets.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            targets.Remove(collision.gameObject);
        }
    }

    public bool IsTargetInHitbox()
    {
        return targets.Count > 0;
    }

    public void ApplyDamage(int damage)
    {
        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].GetComponent<Health>().ReduceHealth(damage);
        }
    }
}
