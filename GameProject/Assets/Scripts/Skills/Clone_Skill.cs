using UnityEngine;

public class Clone_Skill : Skill
{

    [SerializeField] private GameObject clonePrefab;    
    [SerializeField] private float cloneDuration;
    [Space]
    [SerializeField] private bool canAttack;
    

    public void CriarClone(Transform _clonePosition)
    {
        GameObject newClone = Instantiate(clonePrefab);

        newClone.GetComponent<Clone_Skill_Controller>().SetupClone(_clonePosition, cloneDuration, canAttack);
    }
}
