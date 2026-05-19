using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    private Coroutine invencibleCoroutine;
    private Coroutine speedCoroutine;
    private Coroutine damage2XCoroutine;

    [SerializeField] private PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EquipPowerup(TypePowerup type)
    {
        switch (type)
        {
            case TypePowerup.INVENCIBLE:
                if(invencibleCoroutine != null)
                {
                    StopCoroutine(invencibleCoroutine);
                }

                // Lógica para invencibilidade
                invencibleCoroutine = StartCoroutine(PlayerInvencible());
                break;
            case TypePowerup.HEAL:
                // Lógica para curar o jogador
                GetComponent<Health>().GainHealth(40);
                break;
            case TypePowerup.SPEED:
                if (speedCoroutine != null)
                {
                    StopCoroutine(speedCoroutine);
                }

                // Lógica para aumentar a velocidade do jogador
                speedCoroutine = StartCoroutine(ActivateSpeed());
                break;
            case TypePowerup.DAMAGE2X:
                if (damage2XCoroutine != null) 
                {
                    StopCoroutine(damage2XCoroutine);
                }
                // Lógica para dobrar o dano do jogador
                damage2XCoroutine = StartCoroutine(ActivateDamage2X());
                break;
            
        }
    }

    private IEnumerator PlayerInvencible()
    {
        gameObject.layer = LayerMask.NameToLayer("Invunerable");
        playerUI.ChangeVisibility(TypePowerup.INVENCIBLE, true);

        float contador = 0f;
        while(contador < 5f)
        {
            contador += Time.deltaTime;
            playerUI.UpdatePowerupProgress(TypePowerup.INVENCIBLE, contador / 5f);
            yield return null;
        }

        playerUI.ChangeVisibility(TypePowerup.INVENCIBLE, false);
        gameObject.layer = LayerMask.NameToLayer("Character");
    }

    private IEnumerator ActivateSpeed()
    {
        playerUI.ChangeVisibility(TypePowerup.SPEED, true);
        GetComponent<Movement>().IncreseSpeed();

        float timer = 0f;
        while (timer < 10f)
        {
            timer += Time.deltaTime;
            playerUI.UpdatePowerupProgress(TypePowerup.SPEED, timer / 10f);
            yield return null;
        }

        GetComponent<Movement>().ResetSpeed();
        playerUI.ChangeVisibility(TypePowerup.SPEED, false);
    }

    private IEnumerator ActivateDamage2X()
    {
        playerUI.ChangeVisibility(TypePowerup.DAMAGE2X, true);
        GetComponent<Attack>().IncreseAttackDamage();

        float timer = 0f;
        while(timer < 10f)
        {
            timer += Time.deltaTime;
            playerUI.UpdatePowerupProgress(TypePowerup.DAMAGE2X, timer / 10f);
            yield return null;
        }

        GetComponent<Attack>().ResetDamage();
        playerUI.ChangeVisibility(TypePowerup.DAMAGE2X, false);
    }
}
