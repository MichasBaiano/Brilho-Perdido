using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Baleia : Inimigo
{
    [SerializeField] public Transform jogadorTracker;
    public BaleiaDeath morto;
    public BaleiaIdleState inativo;
    public BaleiaBrigaState briga;
    public BaleiaAtaqueState ataque;

    protected override void Awake()
    {
        base.Awake();
        morto = new BaleiaDeath(this, maquina, "inativo", this);
        inativo = new BaleiaIdleState(this, maquina, "inativo", this);
        briga = new BaleiaBrigaState(this, maquina, "inativo", this);
        ataque = new BaleiaAtaqueState(this, maquina, "ataque", this);
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
}
