using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;
    [SerializeField] private PlayerUI playerUI;

    private bool canAttack = true;

    [SerializeField] private Hitbox hitbox;
    [SerializeField] private int damage = 20;

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
}
