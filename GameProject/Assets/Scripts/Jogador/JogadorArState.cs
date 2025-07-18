using Unity.VisualScripting;
using UnityEngine;

public class JogadorArState : JogadorState
{
    public JogadorArState(Jogador _jogador, JogadorStateMachine _stateMachine, string _nomeAnimation) : base(_jogador, _stateMachine, _nomeAnimation)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (jogador.paredeDetectado())
            maquina.MudarState(jogador.wall);

        if (xInput != 0)
            jogador.SetVelocidade(jogador.andarVelocidade * 0.8f * xInput, rb.linearVelocityY);

        if (jogador.chaoDetectado())
        {
            maquina.MudarState(jogador.inativo);
        }
    }
}
