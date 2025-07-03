using UnityEngine;

public class JogadorAnimationTriggers : MonoBehaviour
{
    private Jogador jogador => GetComponentInParent<Jogador>();

    private void AnimationTrigger()
    {
        jogador.AnimationTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(jogador.attackCheck.position, jogador.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Inimigo>() != null)
                hit.GetComponent<Inimigo>().Damage();
        }
    }

    private void ThrowSword()
    {
        SkillManager.instancia.sword.CreateSword();
    }
}
