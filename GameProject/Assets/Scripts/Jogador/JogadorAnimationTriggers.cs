using UnityEngine;

public class JogadorAnimationTriggers : MonoBehaviour
{
    private Jogador jogador => GetComponentInParent<Jogador>();

    private void AnimationTrigger()
    {
        jogador.AnimationTrigger();
    }
}
