using UnityEngine;

public class Inimigo1IdleState : Inimigo1ChaoState
{
    public Inimigo1IdleState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Inimigo1 _inimigo) : base(_inimigoBase, _maquina, _nomeAnimation, _inimigo)
    {
    }

    public override void Enter()
    {
        base.Enter();

        tempoState = inimigo.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (tempoState < 0)
            maquina.MudarState(inimigo.mexido);
    }
}
