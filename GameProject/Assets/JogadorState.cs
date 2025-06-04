using UnityEngine;

public class JogadorState
{
    protected Jogador jogador; 
    protected JogadorStateMachine maquina;

    protected Rigidbody2D  rb;

    protected float xInput;
    private string nomeAnimation;

    protected float tempoState;

    public JogadorState(Jogador _jogador, JogadorStateMachine _maquina, string _nomeAnimation)
    {
        this.jogador = _jogador;
        this.maquina = _maquina;
        this.nomeAnimation = _nomeAnimation;
    }

    public virtual void Enter() 
    {
        jogador.anim.SetBool(nomeAnimation, true);
        rb = jogador.rb;
    }

    public virtual void Update()
    {
        tempoState -= Time.deltaTime;

        xInput = Input.GetAxisRaw("Horizontal");   
        jogador.anim.SetFloat("yVelocidade", rb.linearVelocityY);
    }

    public virtual void Exit() 
    {
        jogador.anim.SetBool(nomeAnimation, false);
    }
}
