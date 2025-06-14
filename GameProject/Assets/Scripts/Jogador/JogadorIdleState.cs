using UnityEngine;

public class JogadorIdleState : JogadorChaoState
{
    public JogadorIdleState(Jogador _jogador, JogadorStateMachine _stateMachine, string _nomeAnimation) : base(_jogador, _stateMachine, _nomeAnimation)
    {
    }

    public override void Enter()
    {
        base.Enter();

        rb.linearVelocity = new Vector2(0, 0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(xInput != 0) { 
            maquina.MudarState(jogador.mexido);
        }
    }
}
