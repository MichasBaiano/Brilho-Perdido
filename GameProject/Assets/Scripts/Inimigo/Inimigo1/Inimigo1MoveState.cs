using UnityEngine;

public class Inimigo1MoveState : Inimigo1ChaoState
{
    public Inimigo1MoveState(Inimigo _inimigoBase, InimigoStateMachine _maquina, string _nomeAnimation, Inimigo1 _inimigo) : base(_inimigoBase, _maquina, _nomeAnimation, _inimigo)
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

        inimigo.SetVelocidade(inimigo.moveSpeed * inimigo.caraDirecao, inimigo.rb.linearVelocityY);

        if (inimigo.paredeDetectado() || !inimigo.chaoDetectado())
        {
            inimigo.Flip();
            inimigo.ZeroVelocity();
            maquina.MudarState(inimigo.inativo);
        }
    }
}
