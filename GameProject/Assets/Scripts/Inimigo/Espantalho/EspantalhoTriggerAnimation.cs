using UnityEngine;

public class EspantalhoTriggerAnimation : MonoBehaviour
{
    private Espantalho inimigo => GetComponentInParent<Espantalho>();

    private void AnimationTrigger()
    {
        inimigo.AnimationFinishTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(inimigo.attackCheck.position, inimigo.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Jogador>() != null)
            {
                hit.GetComponent<Jogador>().Damage();
                hit.GetComponent<InimigoStats>().TomarDano(inimigo.stats.dano.getValor());
            }
        }
    }

    private void OpenCounterWindow() => inimigo.OpenCounterWindow();

    private void CloseCounterWindow() => inimigo.CloseCounterWindow();

}