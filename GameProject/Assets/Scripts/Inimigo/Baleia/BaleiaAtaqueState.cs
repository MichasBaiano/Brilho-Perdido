using UnityEngine;

public class BaleiaAtaqueState : InimigoState
{
    private Baleia inimigo;
    public BaleiaAtaqueState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Baleia inimigo) : base(_inimigoBase, _maquina, _nomeAnimation)
    {
        this.inimigo = inimigo;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("mudei o state");
    }

    public override void Exit()
    {
        base.Exit();
        inimigo.ultimoAtaque = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
        {
            maquina.MudarState(inimigo.briga);
        }
    }
}