using UnityEngine;

public class EspantalhoAtaqueState : InimigoState
{
    private Espantalho inimigo;
    public EspantalhoAtaqueState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Espantalho inimigo) : base(_inimigoBase, _maquina, _nomeAnimation)
    {
        this.inimigo = inimigo;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        inimigo.ultimoAtaque = Time.time;
    }

    public override void Update()
    {
        base.Update();

        inimigo.ZeroVelocity();

        if (triggerCalled)
        {
            maquina.MudarState(inimigo.briga);
        }
    }
}
