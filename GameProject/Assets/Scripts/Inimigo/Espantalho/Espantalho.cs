using UnityEngine;

public class Espantalho : Inimigo
{
    public EspantalhoIdle inativo { get; private set; }
    public EspantalhoBrigaState briga { get; private set; }
    public EspantalhoAtaqueState ataque { get; private set; }
    public EspantalhoDeathState morto { get; private set; }
    public EspantalhoStunState stun { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        inativo = new EspantalhoIdle(this, maquina, "inativo", this);
        briga = new EspantalhoBrigaState(this, maquina, "briga", this);
        ataque= new EspantalhoAtaqueState(this, maquina, "ataque", this);
        morto = new EspantalhoDeathState(this, maquina, "idle", this);
        stun = new EspantalhoStunState(this, maquina, "briga", this);
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

    public override void Morrer()
    {
        base.Morrer();
        maquina.MudarState(morto);
    }

    public override bool CanBeStunned()
    {
        if (base.CanBeStunned())
        {
            maquina.MudarState(stun);
            return true;
        }
        return false;
    }


}
