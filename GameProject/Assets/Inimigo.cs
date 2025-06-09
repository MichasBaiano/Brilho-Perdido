 using UnityEngine;

public class Inimigo : Entidade 
{
    public InimigoStateMachine maquina { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        maquina = new InimigoStateMachine();
    }

    protected override void Update()
    {
        base.Update();
        maquina.atualState.Update();
    }
}
