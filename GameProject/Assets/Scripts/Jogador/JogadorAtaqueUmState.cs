using UnityEngine;

public class JogadorAtaqueUmState : JogadorState
{
    private int comboCounter;

    private float lastTimeAttacked;
    private float comboWindow = 2;
        
    public JogadorAtaqueUmState(Jogador _jogador, JogadorStateMachine _maquina, string _nomeAnimation) : base(_jogador, _maquina, _nomeAnimation)
    {
    }

    public override void Enter()
    {
        base.Enter();

        xInput = 0;

        if(comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
            comboCounter = 0;

        jogador.anim.SetInteger("ComboCounter", comboCounter);

        #region Lado do Ataque
        float attackDir = jogador.caraDirecao;

        if(xInput != 0)
            attackDir = xInput;

        #endregion

        jogador.SetVelocidade(jogador.attackMovement[comboCounter].x * attackDir, jogador.attackMovement[comboCounter].y);

        tempoState = .1f;
    }

    public override void Exit()
    {
        base.Exit();

        jogador.StartCoroutine("BusyFor", .15f);

        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if (tempoState < 0)
            jogador.ZeroVelocity();

        if (triggerCalled)
            maquina.MudarState(jogador.inativo);
    }
}
