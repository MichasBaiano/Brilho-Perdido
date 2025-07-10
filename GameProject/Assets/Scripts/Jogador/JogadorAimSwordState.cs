using UnityEngine;

public class JogadorAimSwordState : JogadorState
{
    public JogadorAimSwordState(Jogador _jogador, JogadorStateMachine _maquina, string _nomeAnimation) : base(_jogador, _maquina, _nomeAnimation)
    {
    }

    public override void Enter()
    {
        base.Enter();

        jogador.skill.sword.DotsActive(true);   
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyUp(KeyCode.Mouse1))
            maquina.MudarState(jogador.inativo);    
    }
}
