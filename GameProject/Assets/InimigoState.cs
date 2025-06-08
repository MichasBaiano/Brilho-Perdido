using Unity.VisualScripting;
using UnityEngine;

public class InimigoState
{

    protected InimigoStateMachine maquina;
    protected Inimigo inimigo;

    private string nomeAnimation;

    protected float tempoState;
    protected bool triggerCalled;

    public InimigoState(Inimigo _inimigo, InimigoStateMachine _maquina, string _nomeAnimation) 
    {
        this.inimigo = _inimigo;
        this.maquina = _maquina;
        this.nomeAnimation = _nomeAnimation;
    }

    public virtual void Update() 
    {
        tempoState = Time.deltaTime;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        inimigo.animator.SetBool(nomeAnimation, true);
    }

    public virtual void Exit()
    {
        inimigo.animator.SetBool(nomeAnimation, false);
    }
}
