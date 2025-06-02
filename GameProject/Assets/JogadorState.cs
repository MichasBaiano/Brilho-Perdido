using UnityEngine;

public class JogadorState
{
    protected Jogador jogador; 
    protected JogadorStateMachine stateMachine;

    private string nomeAnimation;

    public JogadorState(Jogador _jogador, JogadorStateMachine _stateMachine, string _nomeAnimation)
    {
        this.jogador = _jogador;
        this.stateMachine = _stateMachine;
        this.nomeAnimation = _nomeAnimation;
    }

    public virtual void Enter() 
    {
        jogador.anim.SetBool(nomeAnimation, true);
    }

    public virtual void Update()
    {
        Debug.Log("Eu estou " + nomeAnimation);
    }

    public virtual void Exit() 
    {
        jogador.anim.SetBool(nomeAnimation, false);
    }
}
