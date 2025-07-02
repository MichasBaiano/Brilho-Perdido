using UnityEngine;

public class EspantalhoBrigaState : InimigoState
{
    private Espantalho inimigo;
    private Transform jogador;
    private int moveDir;
    public EspantalhoBrigaState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Espantalho inimigo) : base(_inimigoBase, _maquina, _nomeAnimation)
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

        if (inimigo.isJogadorDetectado())
        {
            tempoState = inimigo.tempoDeBriga;
            if (inimigo.isJogadorDetectado().distance < inimigo.ataqueDistancia)
            {
                if (PodeAtacar())
                    maquina.MudarState(inimigo.ataque);
            }
        }
        else
        {
            if (tempoState < 0 && Vector2.Distance(jogador.transform.position, inimigo.transform.position) > 10)
            {
                maquina.MudarState(inimigo.inativo);
            }
        }

        if (jogador.position.x > inimigo.transform.position.x)
        {
            moveDir = 1;
        }
        else if (jogador.position.x < inimigo.transform.position.x)
        {
            moveDir = -1;
        }

        inimigo.SetVelocidade(inimigo.moveSpeed * moveDir, rb.linearVelocityY);
    }

    private bool PodeAtacar()
    {
        if (Time.time >= inimigo.ultimoAtaque + inimigo.ataquaCooldown)
        {
            inimigo.ultimoAtaque = Time.time;
            return true;
        }

        return false;
    }
}
