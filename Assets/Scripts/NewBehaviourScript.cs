using UnityEngine;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private float speed; // Velocidade do jogador
    private bool grounded; // Indica se o jogador está no chão
    [SerializeField] private GameObject attackHitbox; // Referência à hitbox de ataque

    private void Awake()
    {
        // Pega as referências do Rigidbody2D e do Animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Obtém o movimento horizontal

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y); // Aplica o movimento

        // Girar sprites para a direita e esquerda
        if (horizontalInput > 0.01)
        {
            transform.localScale = new Vector3(2, 2, 1); // Olha para a direita
        }
        else if (horizontalInput < -0.01)
        {
            transform.localScale = new Vector3(-2, 2, 1); // Olha para a esquerda
        }

        // Pulo
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        // Ataque
        if (Input.GetKey(KeyCode.Z) && canAttack()) // Verifica se o jogador pode atacar
        {
            anim.SetTrigger("attack"); // Ativa a animação de ataque
        }

        // Parâmetros de animação
        anim.SetBool("run", horizontalInput != 0);  // Corre quando se move horizontalmente
        anim.SetBool("grounded", grounded);         // Controla a animação de pulo
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed); // Aplica a velocidade do pulo
        grounded = false; // O jogador não está mais no chão
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true; // O jogador tocou o chão
        }
    }

    public bool canAttack()
    {
        return grounded; // Só pode atacar se estiver no chão
    }

    // Este método será chamado pelo evento de animação para ativar a hitbox de ataque
    public void EnableAttackHitbox()
    {
        if (attackHitbox != null)
        {
            attackHitbox.SetActive(true); // Ativa a hitbox de ataque
        }
    }

    // Este método será chamado pelo evento de animação para desativar a hitbox de ataque
    public void DisableAttackHitbox()
    {
        if (attackHitbox != null)
        {
            attackHitbox.SetActive(false); // Desativa a hitbox de ataque após o ataque
        }
    }
}