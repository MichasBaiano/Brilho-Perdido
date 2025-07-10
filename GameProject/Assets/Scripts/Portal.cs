using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private Transform jogador;
    [SerializeField] private string nomeDaCena = "fase1real";
    [SerializeField] private FadeTela fade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jogador = JogadorManager.instancia.jogador.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, jogador.transform.position) < 1)
        {
            StartCoroutine(CarregarTelaComFade(1.5f));
        }
    }

    IEnumerator CarregarTelaComFade(float _delay)
    {
        fade.fadeOut();
        JogadorManager.instancia.jogador.ZeroVelocity();

        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(nomeDaCena);
    }
}
