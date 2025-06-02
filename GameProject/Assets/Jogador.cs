using Unity.VisualScripting;
using UnityEngine;

public class Jogador : MonoBehaviour
{

    #region Components
    public Animator anim {  get; private set; }
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

        maquina.Initialize(inativo);
    }

    private void Update()
    {
        maquina.atualState.Update();
    }
}
