using UnityEngine;

public class EspantalhoDeathState : InimigoState
{
    Espantalho inimigo;
    public EspantalhoDeathState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Espantalho inimigo) : base(_inimigoBase, _maquina, _nomeAnimation)
    {
        this.inimigo = inimigo;
    }

    public override void Enter()
    {
        base.Enter();

        inimigo.anim.SetBool(inimigo.ultimaAnimBoolname, true);
        inimigo.anim.speed = 0;
        inimigo.cd.enabled = false;

        tempoState = .1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (tempoState > 0)
        {
            rb.linearVelocity = new Vector2(0, 10);
        }
    }
}
