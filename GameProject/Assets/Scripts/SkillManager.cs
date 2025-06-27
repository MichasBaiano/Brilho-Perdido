using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instancia;

    public Dash_Skill dash { get; private set; }

    private void Awake()
    {
        if (instancia != null)
            Destroy(instancia.gameObject);
        else
            instancia = this;
    }

    private void Start()
    {
        dash = GetComponent<Dash_Skill>();
    }
}
