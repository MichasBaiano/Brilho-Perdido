using Unity.VisualScripting;
using UnityEngine;

public class Jogador : MonoBehaviour
{

    [Header ("Dados da Movimenta��o")]
    public float andarVelocidade = 12f; 


    #region Components
    public Animator anim {  get; private set; }
    public Rigidbody2D rb {  get; private set; }
    #endregion

    #region States
    public JogadorStateMachine maquina  { get; private set; }
    public JogadorIdleState inativo{ get; private set; }
    public JogadorMoveState mexido{ get; private set; }
    #endregion

    private void Awake()
    {
        maquina =  new JogadorStateMachine();

        inativo = new JogadorIdleState(this, maquina, "inativo");
        mexido = new JogadorMoveState(this, maquina, "mexido");
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

    public void setVelocidade(float _xVelocidade, float _yVelocidade) => rb.linearVelocity = new Vector2(_xVelocidade, _yVelocidade);
}
