using UnityEngine;

public class Espantalho : Inimigo
{
    public EspantalhoIdle inativo { get; private set; }
    public EspantalhoBrigaState briga { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        inativo = new EspantalhoIdle(this, maquina, "inativo", this);
        briga = new EspantalhoBrigaState(this, maquina, "briga", this);
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
}
