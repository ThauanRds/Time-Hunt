using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private int damage;
    private int speed;

    [SerializeField] private GameObject explosion;
    private bool ignoreEnemies;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyProjetil), 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.tag == "Enemy" && ignoreEnemies))
        {
            collision.gameObject.GetComponent<Health>()?.ReduceHealth(damage);
        }

        DestroyProjetil();
    }

    public void LaunchFireBall(Transform target, int speed, int damage, bool ignoreEnemies)
    {
        if(target != null)
        {
            transform.right = target.position - transform.position;
        }

        this.speed = speed;
        this.damage = damage;
        this.ignoreEnemies = ignoreEnemies;
    }

    private void DestroyProjetil()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
