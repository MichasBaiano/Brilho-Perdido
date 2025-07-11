using UnityEngine;

public class BaleiaDeath : InimigoState
{
    private Baleia inimigo;
    public BaleiaDeath(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Baleia inimigo) : base(_inimigoBase, _maquina, _nomeAnimation)
    {
        this.inimigo = inimigo;
    }

    public override void Enter()
    {
        base.Enter();

        AudioManager.instance.PlayBGM(2);

        inimigo.anim.SetBool(inimigo.ultimaAnimBoolname, true);
        inimigo.anim.speed = 0;
        inimigo.cd.enabled = false;
        inimigo.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
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
