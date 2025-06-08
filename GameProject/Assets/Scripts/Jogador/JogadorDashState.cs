using UnityEngine;

public class JogadorDashState : JogadorState
{
    public JogadorDashState(Jogador _jogador, JogadorStateMachine _stateMachine, string _nomeAnimation) : base(_jogador, _stateMachine, _nomeAnimation)
    {
    }

    public override void Enter()
    {
        base.Enter();

        tempoState = jogador.dashDuracao;
    }

    public override void Exit()
    {
        base.Exit();

        jogador.SetVelocidade(0, rb.linearVelocityY);
    }

    public override void Update()
    {
        base.Update();

        jogador.SetVelocidade(jogador.dashVelocidade * jogador.dashDirecao, 0);

        if (!jogador.chaoDetectado() && jogador.paredeDetectado())
            maquina.MudarState(jogador.inativo);

        if (tempoState < 0)
            maquina.MudarState(jogador.inativo);
    }
}
