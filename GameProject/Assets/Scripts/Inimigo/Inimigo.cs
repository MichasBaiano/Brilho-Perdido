using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Inimigo : Entidade 
{
    [SerializeField] protected LayerMask eJogador;
    [Header ("Move Info")]
    public float moveSpeed;
    public float idleTime;
    public float tempoDeBriga;

    [Header("Ataque info")]
    public float ataqueDistancia;
    public float ataquaCooldown;
    [HideInInspector] public float ultimoAtaque;
    public InimigoStateMachine maquina { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        maquina = new InimigoStateMachine();
    }

    protected override void Update()
    {
        base.Update();
        maquina.atualState.Update();
        
    }

    public virtual void AnimacaoGatilhoFinal() => maquina.atualState.AnimacaoGatilhoFinal();

    public virtual RaycastHit2D isJogadorDetectado() => Physics2D.Raycast(paredeCheck.position, Vector2.right * caraDirecao, 50, eJogador);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + ataqueDistancia * caraDirecao, transform.position.y));
    }
}
