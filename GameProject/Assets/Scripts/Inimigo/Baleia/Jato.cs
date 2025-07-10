using UnityEngine;

public class Jato : MonoBehaviour
{
    [SerializeField] int dano;
    [SerializeField] float xVelocidade;
    [SerializeField] Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(xVelocidade, rb.linearVelocityY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entrou");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Jogador"))
        {
            collision.GetComponent<PersonagemStats>().TomarDano(dano);
            collision.GetComponent<Jogador>().Damage();
        }
    }
}
