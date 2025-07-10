using UnityEngine;

public class Inimigo1AtaqueState : InimigoState
{
    private Inimigo1 inimigo;
    public Inimigo1AtaqueState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Inimigo1 _inimigo1) : base(_inimigoBase, _maquina, _nomeAnimation)
    {
        this.inimigo = _inimigo1;
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
