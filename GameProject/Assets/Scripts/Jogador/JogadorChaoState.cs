using UnityEngine;

public class JogadorChaoState : JogadorState
{
    public JogadorChaoState(Jogador _jogador, JogadorStateMachine _stateMachine, string _nomeAnimation) : base(_jogador, _stateMachine, _nomeAnimation)
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
            maquina.MudarState(jogador.ataqueUm);

        if (!jogador.chaoDetectado())
            maquina.MudarState(jogador.ar);

        if (Input.GetKeyDown(KeyCode.Space) && jogador.chaoDetectado())
        {
            maquina.MudarState(jogador.pulo);
        }
    }
}
