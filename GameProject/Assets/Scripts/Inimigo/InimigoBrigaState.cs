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

        if (Inimigo.isJogadorDetectado())
        {
            tempoState = Inimigo.tempoDeBriga;
            if (Inimigo.isJogadorDetectado().distance < Inimigo.ataqueDistancia)
            {
                if (PodeAtacar())
                    maquina.MudarState(Inimigo.ataque);
            }
        }
        else
        {
            if(tempoState < 0 || Vector2.Distance(jogador.transform.position, Inimigo.transform.position) > 7)
            {
                maquina.MudarState(Inimigo.inativo);
            }
        }

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

    private bool PodeAtacar()
    {
        if(Time.time >= Inimigo.ultimoAtaque + Inimigo.ataquaCooldown)
        {
            Inimigo.ultimoAtaque = Time.time;
            return true;   
        }

        return false;   
    }

}
