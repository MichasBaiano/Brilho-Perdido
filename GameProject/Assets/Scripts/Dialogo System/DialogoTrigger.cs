using UnityEngine;

public class DialogoTrigger : MonoBehaviour
{
    [SerializeField]public Dialogo dialogo;
    [SerializeField] public DialogoManager manager;
    private Transform jogador;
    private bool jogadorDentroRange = false;
    public float distanciaParaFalar = 3f;

    public void TriggerDialogo()
    {
        manager.comecarDialogo(dialogo);
    }


    public void Start()
    {
        jogador = JogadorManager.instancia.jogador.transform;
        
    }

    public void Update()
    {
        float distancia = Vector2.Distance(transform.position, jogador.transform.position);

        if (!jogadorDentroRange && distancia < distanciaParaFalar)
        {
            jogadorDentroRange = true;
            Debug.Log("Entrou na range");
            TriggerDialogo();
        }
        else if (jogadorDentroRange && distancia >= distanciaParaFalar)
        {
            jogadorDentroRange = false;
            manager.finalizarDialogo();
            Debug.Log("Saiu da range");
        }
    }
}
