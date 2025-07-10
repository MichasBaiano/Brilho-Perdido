using UnityEngine;

public class Inimigo1StunnedState : InimigoState
{
    private Inimigo1 inimigo;
    public Inimigo1StunnedState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Inimigo1 _inimigo) : base(_inimigoBase, _maquina, _nomeAnimation)
    {
        this.inimigo = _inimigo;
    }

    public override void Enter()
    {
        base.Enter();

        inimigo.fx.InvokeRepeating("RedColorBlink",0,0.1f);

        tempoState = inimigo.stunDuration;

        rb.linearVelocity = new Vector2(-inimigo.caraDirecao * inimigo.stunDiraction.x, inimigo.stunDiraction.y);
    }

    public override void Exit()
    {
        base.Exit();

        inimigo.fx.Invoke("CancelarRedBlink",0);
    }

    public override void Update()
    {
        base.Update();

        if (tempoState < 0)
            maquina.MudarState(inimigo.inativo);

    }
}