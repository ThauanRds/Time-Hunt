using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private TypePowerup type;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(ActiveCollider), 1f);
    }

    private void ActiveCollider()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PowerupController>().EquipPowerup(type);
            Destroy(gameObject);
        }
    }
}
