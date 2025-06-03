using UnityEngine;

public class JogadorPuloState : JogadorState
{
    public JogadorPuloState(Jogador _jogador, JogadorStateMachine _stateMachine, string _nomeAnimation) : base(_jogador, _stateMachine, _nomeAnimation)
    {
    }

    public override void Enter()
    {
        base.Enter();

        rb.linearVelocity = new Vector2(rb.linearVelocityX, jogador.forcaPulo);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (rb.linearVelocityY < 0)
        {
            stateMachine.ChangeState(jogador.ar);
        }
    }
}
