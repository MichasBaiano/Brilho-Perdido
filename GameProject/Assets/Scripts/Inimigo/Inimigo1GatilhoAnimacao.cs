using UnityEngine;

public class Inimigo1GatilhoAnimacao : MonoBehaviour
{
    private Inimigo1 inimigo => GetComponentInParent<Inimigo1>();

    private void AnimacaoGatilho() {
        inimigo.AnimacaoGatilhoFinal();
    }
}
