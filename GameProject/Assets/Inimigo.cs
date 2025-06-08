using UnityEngine;

public class Inimigo : MonoBehaviour 
{
    public Rigidbody2D rb {  get; private set; }
    public Animator animator { get; private set; }

    public InimigoStateMachine maquina { get; private set; }

    private void Awake()
    {
        maquina = new InimigoStateMachine();
    }

    private void Update()
    {
        maquina.atualState.Update();
    }
}
