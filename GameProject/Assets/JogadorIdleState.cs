using UnityEngine;

public class JogadorIdleState : JogadorState
{
    public JogadorIdleState(Jogador _jogador, JogadorStateMachine _stateMachine, string _nomeAnimation) : base(_jogador, _stateMachine, _nomeAnimation)
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

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Eu estou Funcionando");
            stateMachine.ChangeState(jogador.mexido);
        }
    }
}
