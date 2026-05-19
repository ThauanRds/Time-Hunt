using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysManager : MonoBehaviour
{
    [SerializeField] private GameObject keyPrefab;
    [SerializeField] private GameObject effectParticle;
    [SerializeField] private List<Transform> keySpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            int random = Random.Range(0, keySpawnPoints.Count);
            Instantiate(keyPrefab, keySpawnPoints[random].position, Quaternion.identity);
            keySpawnPoints.RemoveAt(random);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            Instantiate(effectParticle, collision.transform.position, collision.transform.rotation);
            collision.collider.enabled = false;
            GameManager.instance.KeyCollected();
            Destroy(collision.gameObject);
        }
    }

   
}
