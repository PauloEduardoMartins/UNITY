using UnityEngine;

public class Rato : MonoBehaviour
{
    [SerializeField] private float damage = 10f;          // Dano causado pelo inimigo
    [SerializeField] private float attackCooldown = 1f;   // Intervalo entre os ataques em segundos
    private float lastAttackTime = 0f;                    // Marca o tempo do último ataque

    private Animator anim;                                // Referência ao Animator

    private void Awake()
    {
        anim = GetComponent<Animator>(); // Inicializa o Animator
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack(collision);
        }
    }

    private void Attack(Collider2D player)
    {
        // Reproduz a animação de ataque
        if (anim != null)
        {
            anim.SetTrigger("ataqueRato");
        }

        // Aplica dano ao jogador
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }

        // Atualiza o tempo do último ataque
        lastAttackTime = Time.time;
    }
}

