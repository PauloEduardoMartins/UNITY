using UnityEngine;

public class gatoAtaque : MonoBehaviour
{
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private NewBehaviourScript playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<NewBehaviourScript>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            attack();
        }
        cooldownTimer += Time.fixedDeltaTime;
    }

    private void attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }
}