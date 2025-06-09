using UnityEngine;

public class Entidade : MonoBehaviour
{

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    [Header("Colisao Info")]
    [SerializeField] protected Transform chaoCheck;
    [SerializeField] protected Transform paredeCheck;
    [SerializeField] protected float chaoCheckDistancia;
    [SerializeField] protected float paredeCheckDistancia;
    [SerializeField] protected LayerMask eChao;

    public int caraDirecao { get; private set; }
    protected bool caraDireita = true;

    protected virtual void Awake()
    {
        caraDirecao = 1;
    }

    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Update()
    {
        
    }

    #region Velocidade
    public void ZeroVelocity() => rb.linearVelocity = new Vector2 (0, 0);
    public void SetVelocidade(float _xVelocidade, float _yVelocidade)
    {
        rb.linearVelocity = new Vector2(_xVelocidade, _yVelocidade);
        FlipController(_xVelocidade);
    }
    #endregion
    #region Colisão
    public virtual bool chaoDetectado() => Physics2D.Raycast(chaoCheck.position, Vector2.down, chaoCheckDistancia, eChao);
    public virtual bool paredeDetectado() => Physics2D.Raycast(paredeCheck.position, Vector2.right * caraDirecao, paredeCheckDistancia, eChao);

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(chaoCheck.position, new Vector3(chaoCheck.position.x, chaoCheck.position.y - chaoCheckDistancia));
        Gizmos.DrawLine(paredeCheck.position, new Vector3(paredeCheck.position.x + paredeCheckDistancia, paredeCheck.position.y));
    }
    #endregion
    #region Flip
    public virtual void Flip()
    {
        caraDirecao = caraDirecao * -1;
        caraDireita = !caraDireita;
        transform.Rotate(0, 180, 0);
    }

    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !caraDireita)
            Flip();
        else if (_x < 0 && caraDireita)
            Flip();
    }
    #endregion
}