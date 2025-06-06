using UnityEngine;

public class JogadorWallJumpState : JogadorState
{
    public JogadorWallJumpState(Jogador _jogador, JogadorStateMachine _maquina, string _nomeAnimation) : base(_jogador, _maquina, _nomeAnimation)
    {
    }

    public override void Enter()
    {
        base.Enter();

        tempoState = .4f;
        jogador.setVelocidade(5 * -jogador.caraDirecao, jogador.forcaPulo);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (tempoState < 0)
            maquina.MudarState(jogador.ar);

        if (jogador.chaoDetectado())
            maquina.MudarState(jogador.inativo);
    }
}
