using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] private string nomeDaCena = "Tutorial";
    [SerializeField] private FadeTela fade;

    public void Awake()
    {
        
    }

    public void novoJogo()
    {
        StartCoroutine(CarregarTelaComFade(1.5f));
        
    }

    IEnumerator CarregarTelaComFade(float _delay)
    {
        fade.fadeOut();

        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(nomeDaCena);
    }
}
