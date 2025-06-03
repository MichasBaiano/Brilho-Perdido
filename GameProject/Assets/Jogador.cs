using Unity.VisualScripting;
using UnityEngine;

public class Jogador : MonoBehaviour
{

    [Header ("Dados da Movimentacao")]
    public float andarVelocidade = 12f;
    public float forcaPulo;

    [Header("Colisao Info")]
    [SerializeField] private Transform chaoCheck;
    [SerializeField] private Transform paredeCheck;
    [SerializeField] private float chaoCheckDistancia;
    [SerializeField] private float paredeCheckDistancia;
    [SerializeField] private LayerMask eChao; 

    public int caraDirecao {  get; private set; }
    private bool caraDireita = true;

    #region Components
    public Animator anim {  get; private set; }
    public Rigidbody2D rb {  get; private set; }
    #endregion

    #region States
    public JogadorStateMachine maquina  { get; private set; }
    public JogadorIdleState inativo{ get; private set; }
    public JogadorMoveState mexido{ get; private set; }
    public JogadorPuloState pulo{ get; private set; }
    public JogadorArState ar {  get; private set; }
    #endregion

    private void Awake()
    {
        maquina =  new JogadorStateMachine();

        inativo = new JogadorIdleState(this, maquina, "inativo");
        mexido = new JogadorMoveState(this, maquina, "mexido");
        pulo = new JogadorPuloState(this, maquina, "pulo");
        ar = new JogadorArState(this, maquina, "pulo");
    }

    private void Start()
    {

        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        maquina.Initialize(inativo);
    }

    private void Update()
    {
        maquina.atualState.Update();
    }

    public void setVelocidade(float _xVelocidade, float _yVelocidade)
    {
        rb.linearVelocity = new Vector2(_xVelocidade, _yVelocidade);
        FlipController(_xVelocidade);
    }
    public bool chaoDetectado() => Physics2D.Raycast(chaoCheck.position, Vector2.down, chaoCheckDistancia, eChao);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(chaoCheck.position, new Vector3(chaoCheck.position.x, chaoCheck.position.y - chaoCheckDistancia));
        Gizmos.DrawLine(paredeCheck.position, new Vector3(paredeCheck.position.x + paredeCheckDistancia, paredeCheck.position.y));
    }

    public void Flip()
    {
        caraDirecao = caraDirecao * -1;
        caraDireita = !caraDireita;
        transform.Rotate(0, 180,0);
    }

    public void FlipController(float _x)
    {
        if (_x > 0 && !caraDireita)
            Flip();
        else if (_x < 0 && caraDireita)
            Flip();
    }
}