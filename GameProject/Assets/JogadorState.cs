using UnityEngine;

public class JogadorState
{
    protected Jogador jogador; 
    protected JogadorStateMachine stateMachine;

    protected Rigidbody2D  rb;

    protected float xInput;
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
        rb = jogador.rb;
    }

    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");   

        jogador.anim.SetFloat("yVelocidade", rb.linearVelocityY);
    }

    public virtual void Exit() 
    {
        jogador.anim.SetBool(nomeAnimation, false);
    }
}
