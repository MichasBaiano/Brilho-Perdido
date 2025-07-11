using UnityEngine;

public class JogadorState
{
    protected Jogador jogador; 
    protected JogadorStateMachine maquina;

    protected Rigidbody2D  rb;

    protected float xInput;
    protected float yInput;
    private string nomeAnimation;

    protected float tempoState;
    protected bool triggerCalled;

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
        triggerCalled = false;
    }

    public virtual void Update()
    {
        tempoState -= Time.deltaTime;

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        jogador.anim.SetFloat("yVelocidade", rb.linearVelocityY);
    }

    public virtual void Exit() 
    {
        jogador.anim.SetBool(nomeAnimation, false);
        jogador.DessignarUltimaAnimBoolname(nomeAnimation);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
