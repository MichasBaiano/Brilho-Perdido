using Unity.VisualScripting;
using UnityEngine;

public class Jogador : Entidade
{

    [Header ("Dados da Movimentacao")]
    public float andarVelocidade = 12f;
    public float forcaPulo;

    [Header("Dash Info")]
    [SerializeField] private float dashCooldown;
    private float dashTempoUsado;
    public float dashVelocidade;
    public float dashDuracao;
    public float dashDirecao {  get; private set; }

    #region States
    public JogadorStateMachine maquina  { get; private set; }
    public JogadorIdleState inativo{ get; private set; }
    public JogadorMoveState mexido{ get; private set; }
    public JogadorPuloState pulo{ get; private set; }
    public JogadorArState ar {  get; private set; }
    public JogadorDashState dash { get; private set; }
    public JogadorWallSlideState wall { get; private set; }
    public JogadorWallJumpState wallPulo { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        maquina =  new JogadorStateMachine();

        inativo = new JogadorIdleState(this, maquina, "inativo");
        mexido = new JogadorMoveState(this, maquina, "mexido");
        pulo = new JogadorPuloState(this, maquina, "pulo");
        ar = new JogadorArState(this, maquina, "pulo");
        dash = new JogadorDashState(this, maquina, "dash");
        wall = new JogadorWallSlideState(this, maquina, "wall");
        wallPulo = new JogadorWallJumpState(this, maquina, "pulo");

    }

    protected override void Start()
    {
        base.Start();
        maquina.Initialize(inativo);
    }

    protected override void Update()
    {
        base.Update();

        maquina.atualState.Update();
        checkDashInput();
    }


    public void checkDashInput()
    {
        if (paredeDetectado())
            return;

        dashTempoUsado -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTempoUsado < 0)
        {
            dashTempoUsado = dashCooldown;
            dashDirecao = Input.GetAxisRaw("Horizontal");

            if (dashDirecao == 0)
                dashDirecao = caraDirecao;

            maquina.MudarState(dash);
        }
    }
}