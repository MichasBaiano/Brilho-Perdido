using UnityEngine;

public class JogadorWallSlideState : JogadorState
{
    public JogadorWallSlideState(Jogador _jogador, JogadorStateMachine _maquina, string _nomeAnimation) : base(_jogador, _maquina, _nomeAnimation)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            maquina.MudarState(jogador.wallPulo);
            return;
        }

        if (xInput != 0 && jogador.caraDirecao != xInput)
            maquina.MudarState(jogador.inativo);

        if (yInput < 0)
            rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
        else
            rb.linearVelocity = new Vector2(0, rb.linearVelocityY * 0.7f);
    }
}
