using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Inimigo1 : Inimigo
{

    #region States

    public Inimigo1IdleState inativo {  get; private set; }
    public Inimigo1MoveState mexido { get; private set; }
    public InimigoBrigaState briga { get; private set; }
    public Inimigo1AtaqueState ataque { get; private set; }
    public Inimigo1StunnedState stun { get; private set; }
    public Inimigo1DeathState morto { get; private set; }   
    #endregion

    protected override void Awake()
    {
        base.Awake();

        inativo = new Inimigo1IdleState(this, maquina, "inativo", this);
        mexido = new Inimigo1MoveState(this, maquina, "mexido", this);
        briga = new InimigoBrigaState(this, maquina, "mexido", this);
        ataque = new Inimigo1AtaqueState(this, maquina, "ataque", this);
        stun = new Inimigo1StunnedState(this, maquina, "stun", this);
        morto = new Inimigo1DeathState(this, maquina, "stun", this);
    }

    protected override void Start()
    {
        base.Start();
        maquina.Initialize(inativo);
    }

    protected override void Update()
    {
        base.Update();

    }

    public override bool CanBeStunned()
    {
        if(base.CanBeStunned())
        {
            maquina.MudarState(stun);
            return true;
        }
        return false;
    }

    public override void Morrer()
    {
        base.Morrer();
        maquina.MudarState(morto);
    }

}