using UnityEngine;

public class InimigoBrigaState : InimigoState
{
    private Transform jogador;
    private Inimigo1 Inimigo;
    private int moveDir;
    public InimigoBrigaState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Inimigo1 inimigo) : base(_inimigoBase, _maquina, _nomeAnimation)
    {
        this.Inimigo = inimigo;
    }

    public override void Enter()
    {
        base.Enter();

        jogador = GameObject.Find("Jogador").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (jogador.position.x > Inimigo.transform.position.x)
        {
            moveDir = 1;
        }
        else if (jogador.position.x < Inimigo.transform.position.x)
        {
            moveDir = -1;
        }

        Inimigo.SetVelocidade(Inimigo.moveSpeed * moveDir, rb.linearVelocityY);
    }
}
