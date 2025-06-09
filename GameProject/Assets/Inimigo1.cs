using UnityEngine;

public class Inimigo1 : Inimigo
{

    #region States

    public Inimigo1IdleState inativo {  get; private set; }
    public Inimigo1MoveState mexido { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        inativo = new Inimigo1IdleState(this, maquina, "inativo", this);
        mexido = new Inimigo1MoveState(this, maquina, "mexido", this);
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
