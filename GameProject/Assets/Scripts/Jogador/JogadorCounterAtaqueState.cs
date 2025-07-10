using UnityEngine;

public class JogadorCounterAtaqueState : JogadorState
{
    public JogadorCounterAtaqueState(Jogador _jogador, JogadorStateMachine _maquina, string _nomeAnimation) : base(_jogador, _maquina, _nomeAnimation)
    {
    }

    public override void Enter()
    {
        base.Enter();

        tempoState = jogador.counterAtaqueDuration;
        jogador.anim.SetBool("SucessoCounterAtaque", false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        jogador.ZeroVelocity();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(jogador.attackCheck.position, jogador.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Inimigo>() != null)
            {
                if (hit.GetComponent<Inimigo>().CanBeStunned())
                {
                    tempoState = 10;
                    jogador.anim.SetBool("SucessoCounterAtaque", true); 
                }
            }
        }

        if (tempoState < 10 || triggerCalled)
            maquina.MudarState(jogador.inativo);

    }
}
