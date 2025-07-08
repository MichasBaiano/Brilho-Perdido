using UnityEngine;

public class EspantalhoIdle : InimigoState
{
    private Espantalho inimigo;
    private Transform jogador;
    public EspantalhoIdle(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Espantalho _espantalho) : base(_inimigoBase, _maquina, _nomeAnimation)
    {
        this.inimigo = _espantalho;
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
        inimigo.ZeroVelocity();

        if (inimigo.isJogadorDetectado() || Vector2.Distance(inimigo.transform.position, jogador.transform.position) < 3)
        {
            maquina.MudarState(inimigo.briga);
        }
    }

}

