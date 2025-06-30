using UnityEngine;

public class EspantalhoIdle : InimigoState
{
    private Espantalho inimigo;
    public EspantalhoIdle(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Espantalho _espantalho) : base(_inimigoBase, _maquina, _nomeAnimation)
    {
        this.inimigo = _espantalho;
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
        inimigo.ZeroVelocity();

    }
}
