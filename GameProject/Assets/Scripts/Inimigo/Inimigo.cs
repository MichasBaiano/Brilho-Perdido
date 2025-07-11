using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Inimigo : Entidade 
{
    [SerializeField] protected LayerMask eJogador;

    [Header("Stunned Info")]
    public float stunDuration;
    public Vector2 stunDiraction;
    protected bool canBeStunned;
    [SerializeField] protected GameObject counterImage;

    [Header ("Move Info")]
    public float moveSpeed;
    public float idleTime;
    public float tempoDeBriga;

    [Header("Ataque info")]
    public float ataqueDistancia;
    public float ataquaCooldown;
    public float distanciaBriga;
    [HideInInspector] public float ultimoAtaque;
    public InimigoStateMachine maquina { get; private set; }

    protected override void Start()
    {
        base.Start();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Inimigo"), LayerMask.NameToLayer("Inimigo"));
    }
    protected override void Awake()
    {
        base.Awake();
        gameObject.layer = LayerMask.NameToLayer("Inimigo");
        maquina = new InimigoStateMachine();
    }

    protected override void Update()
    {
        base.Update();
        maquina.atualState.Update();
        
    }


    public virtual void OpenCounterWindow()
    {
        canBeStunned = true;
        counterImage.SetActive(true);
    }

    public virtual void CloseCounterWindow()
    {
        canBeStunned = false;
        counterImage.SetActive(false);
    }

    public virtual bool CanBeStunned()
    {
        if(canBeStunned)
        {
            CloseCounterWindow();
            return true;
        }

        return false;
    } 

    public virtual void AnimationFinishTrigger() => maquina.atualState.AnimationFinishTrigger();

    public virtual RaycastHit2D isJogadorDetectado() => Physics2D.Raycast(paredeCheck.position, Vector2.right * caraDirecao, distanciaBriga, eJogador);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + ataqueDistancia * caraDirecao, transform.position.y));
    }
}
