using UnityEngine;

public class JogadorMoveState : JogadorState
{
    public JogadorMoveState(Jogador _jogador, JogadorStateMachine _stateMachine, string _nomeAnimation) : base(_jogador, _stateMachine, _nomeAnimation)
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

        jogador.setVelocidade(xInput * jogador.andarVelocidade, rb.linearVelocity.y);

        if(xInput == 0) { 
            stateMachine.ChangeState(jogador.inativo);
        }
    }
}
