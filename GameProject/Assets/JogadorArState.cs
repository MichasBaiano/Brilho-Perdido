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

        if (jogador.chaoDetectado())
        {
            maquina.MudarState(jogador.inativo);
        }
    }
}
