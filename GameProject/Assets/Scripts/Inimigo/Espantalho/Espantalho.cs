using UnityEngine;

public class Espantalho : Inimigo
{
    public EspantalhoIdle inativo { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        inativo = new EspantalhoIdle(this, maquina, "inativo", this);
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
