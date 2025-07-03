using Unity.Mathematics;
using UnityEngine;

public class Clone_Skill_Controller : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator anim;
    [SerializeField] private float corPerdendo;

    private float cloneTimer;
    [SerializeField] private Transform attackCheck;
    [SerializeField] private float attackCheckRadius = .8f;
    private Transform closestEnemy;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cloneTimer -= Time.deltaTime;
        
        if (cloneTimer < 0)
        {
            sr.color = new Color(1, 1, 1, sr.color.a - (Time.deltaTime * corPerdendo));
        }

        if (sr.color.a <= 0)
            Destroy(gameObject);
    }

    public void SetupClone(Transform _newTransform, float _cloneDuration, bool _canAttack)
    {
        if (_canAttack)
            anim.SetInteger("AttackNumber", UnityEngine.Random.Range(1, 3));

        transform.position = _newTransform.position;
        cloneTimer = _cloneDuration;


        FaceClosestTarget();
    }


    private void AnimationTrigger()
    {
        cloneTimer = .1f;
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Inimigo>() != null)
                hit.GetComponent<Inimigo>().Damage();
        }
    }
    
    private void FaceClosestTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 25);

        float closestDistance = Mathf.Infinity;

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Inimigo>() != null)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, hit.transform.position);

                if(distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = hit.transform;
                }
            }
        }

        if (closestEnemy != null)
        {
            if (transform.position.x > closestEnemy.position.x)
                transform.Rotate(0, 180, 0);
        }

    }
}
