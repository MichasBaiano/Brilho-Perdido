using UnityEngine;

public class JogadorIdleState : JogadorChaoState
{
    public JogadorIdleState(Jogador _jogador, JogadorStateMachine _stateMachine, string _nomeAnimation) : base(_jogador, _stateMachine, _nomeAnimation)
    {
    }

    public override void Enter()
    {
        base.Enter();

        jogador.ZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(xInput != 0 && !jogador.isBusy) { 
            maquina.MudarState(jogador.mexido);
        }
    }
}
