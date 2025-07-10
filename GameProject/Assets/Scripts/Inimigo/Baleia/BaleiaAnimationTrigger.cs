using UnityEngine;

public class BaleiaAnimationTrigger : MonoBehaviour
{
    private Baleia inimigo => GetComponentInParent<Baleia>();
    [SerializeField] private GameObject jato;


    private void AnimationTrigger()
    {
        inimigo.AnimationFinishTrigger();
    }

    private void AttackTrigger()
    {
        Instantiate(jato, inimigo.jogadorTracker.position, jato.transform.rotation);
    }
}
