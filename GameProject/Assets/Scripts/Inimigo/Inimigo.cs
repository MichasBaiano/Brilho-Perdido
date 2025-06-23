 using UnityEngine;

public class Inimigo : Entidade 
{
    [SerializeField] protected LayerMask eJogador;
    [Header ("Move Info")]
    public float moveSpeed;
    public float idleTime;
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

    public virtual RaycastHit2D isJogadorDetectado() => Physics2D.Raycast(paredeCheck.position, Vector2.right * caraDirecao, 50, eJogador);
}
