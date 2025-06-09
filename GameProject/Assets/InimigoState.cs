using Unity.VisualScripting;
using UnityEngine;

public class InimigoState
{

    protected InimigoStateMachine maquina;
    protected Inimigo inimigoBase;

    private string nomeAnimation;

    protected float tempoState;
    protected bool triggerCalled;

    public InimigoState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation) 
    {
        this.inimigoBase = _inimigoBase;
        this.maquina = _maquina;
        this.nomeAnimation = _nomeAnimation;
    }

    public virtual void Update() 
    {
        tempoState -= Time.deltaTime;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        inimigoBase.anim.SetBool(nomeAnimation, true);
    }

    public virtual void Exit()
    {
        inimigoBase.anim.SetBool(nomeAnimation, false);
    }
}
