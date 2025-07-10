using UnityEngine;

public class Inimigo1DeathState : InimigoState
{
    Inimigo1 inimigo;
    public Inimigo1DeathState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Inimigo1 inimigo) : base(_inimigoBase, _maquina, _nomeAnimation)
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