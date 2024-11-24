using UnityEngine;

public class ratoHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth = 1f;  // Vida inicial do rato
    private float currentHealth;                            // Vida atual do rato

    private void Awake()
    {
        currentHealth = startingHealth; // Inicializa a vida
    }

    // Método para aplicar dano ao rato
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Subtrai o dano da vida atual

        // Verifica se o rato morreu
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método para destruir o rato quando ele morrer
    private void Die()
    {
        Debug.Log("O rato morreu!");
        Destroy(gameObject); // Destrói o rato
    }

    // Detecção de colisão da hitbox de ataque
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o outro objeto que entrou na hitbox é o jogador
        if (other.CompareTag("PlayerAttack")) // Certifique-se de que a hitbox tem a tag "PlayerAttack"
        {
            Debug.Log("O rato foi atingido pela hitbox de ataque!");
            float damage = 10f; // Defina o valor do dano ou pegue do script do jogador
            TakeDamage(damage); // Aplica o dano ao rato
        }
    }
}