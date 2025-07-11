using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI Vida;
    private PersonagemStats jogador;


    
    void Start()
    {
        jogador = JogadorManager.instancia.jogador.stats;
    }

    // Update is called once per frame
    void Update()
    {
        if (jogador == null)
        {
            // Tenta pegar de novo (caso tenha sido carregado após o Start)
            if (JogadorManager.instancia != null && JogadorManager.instancia.jogador != null)
            {
                jogador = JogadorManager.instancia.jogador.stats;
            }
            else
            {
                return; // Ainda não está pronto, sai do Update
            }
        }

        string texto = "Vida: " + jogador.vidaAtual;
        Vida.text = texto;
    }
}
