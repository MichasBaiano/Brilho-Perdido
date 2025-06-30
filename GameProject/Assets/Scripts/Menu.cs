using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] private string nomeDaCena = "fase1real";
    [SerializeField] private FadeTela fade;

    public void novoJogo()
    {
        StartCoroutine(CarregarTelaComFade(2f));
        
    }

    IEnumerator CarregarTelaComFade(float _delay)
    {
        fade.fadeOut();

        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(nomeDaCena);
    }
}
