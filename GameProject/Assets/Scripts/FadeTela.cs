using UnityEngine;

public class FadeTela : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    public void fadeOut() => anim.SetTrigger("fadeOut");
    public void fadeIn() => anim.SetTrigger("fadeIn");
}
