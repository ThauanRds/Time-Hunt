using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;

    [Header("UI: ")]
    [SerializeField] private PlayerUI playerUI;

    [Header("Attack Settings: ")]
    [SerializeField] private Hitbox hitbox;
    [SerializeField] private int damage = 30;

    [Header("Spell Settings: ")]
    [SerializeField] private FireBall fireBallPrefab;
    [SerializeField] private Transform spawnPoint;
    private int spellDamage = 50;

    private bool canAttack = true;
    private bool canSpeel = true;

    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && canAttack)
        {
            StartCoroutine(AttackSword());
        }

        if (Input.GetKeyDown(KeyCode.Y) && canSpeel)
        {
            StartCoroutine(AttackSpell());
        }
    }

    private IEnumerator AttackSword()
    {
        canAttack = false;
        anim.SetTrigger("AttackSword");
        hitbox.ApplyDamage(damage);

        float contador = 0;
        while (contador < 0.6f)
        {
            contador += Time.deltaTime;
            playerUI.UpdateSwordProgress(contador / 0.6f);
            yield return null;
        }

        canAttack = true;
    }

    private IEnumerator AttackSpell()
    {
        canSpeel = false;
        anim.SetTrigger("FireBallAttack");
        yield return new WaitForSeconds(0.3f);

        FireBall fireBall = Instantiate(fireBallPrefab, spawnPoint.position, spawnPoint.rotation);
        fireBall.LaunchFireBall(null, 5, spellDamage, false);

        float contador = 0;
        while (contador < 3)
        {
            contador += Time.deltaTime;
            playerUI.UpdateFireBallProgress(contador / 3);
            yield return null;
        }

        canSpeel = true;
    }
}
