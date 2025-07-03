using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instancia;

    public Dash_Skill dash { get; private set; }
    public Clone_Skill clone { get; private set; }
    public Sword_Skill sword { get; private set; }

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
        clone = GetComponent<Clone_Skill>();
        sword = GetComponent<Sword_Skill>();
    }
}
