using UnityEngine;

public class BaleiaIdleState : InimigoState
{
    private Baleia inimigo;
    private Transform jogador;
    public BaleiaIdleState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Baleia inimigo) : base(_inimigoBase, _maquina, _nomeAnimation)
    {
        this.inimigo = inimigo;
    }

    public override void Enter()
    {
        base.Enter();
        jogador = JogadorManager.instancia.jogador.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Vector2.Distance(inimigo.transform.position, jogador.transform.position) < 10)
        {
            maquina.MudarState(inimigo.briga);
        }
    }
}
