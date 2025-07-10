using UnityEngine;

public class JogadorMoveState : JogadorChaoState
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

        jogador.SetVelocidade(xInput * jogador.andarVelocidade, rb.linearVelocity.y);

        if(xInput == 0 || jogador.paredeDetectado()) 
            maquina.MudarState(jogador.inativo);
    }
}
