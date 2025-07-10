using UnityEngine;


public class Inimigo1ChaoState : InimigoState
{
    protected Inimigo1 inimigo;
    protected Transform jogador;
    public Inimigo1ChaoState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Inimigo1 _inimigo) : base(_inimigoBase, _maquina, _nomeAnimation)
    {
        this.inimigo = _inimigo;
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

        if (inimigo.isJogadorDetectado() || Vector2.Distance(inimigo.transform.position, jogador.transform.position) < 2)
        {
            maquina.MudarState(inimigo.briga);
        }
    }
}
