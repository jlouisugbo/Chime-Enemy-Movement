using UnityEngine;
using UnityEngine.AI;

/// It walks towards the player and attacks when within range
public class WalkerEnemy : Enemy
{
    [SerializeField]
    private float MoveSpeed = 3.0f;

    private NavMeshAgent _Agent;

    /// Start is called before the first frame update. It sets up the Walker enemy with
    /// a NavMeshAgent to handle movement
    protected override void Start(){
        // Call the base Start method to find the player
        base.Start();
        _Agent = GetComponent<NavMeshAgent>();
        _Agent.speed = MoveSpeed;
    }

    void Update(){
        // Check if the player is found
        if (_Player != null){
            // Calculate the distance from the enemy to the player
            float dist = Vector3.Distance(_Player.transform.position, transform.position);

            // If the player is outside the attack radius, move toward the player
            if (dist > AttackRadius) {
                _Agent.SetDestination(_Player.transform.position);
            } else {
                // Stop moving when in attack range
                _Agent.velocity = Vector3.zero;
                Attack();
            }
        }
    }

    /// Attack the player when within the attack radius.
    protected override void Attack(){
        // Here you would define what happens when the WalkerEnemy attacks the player
        // For example, you could reduce the player's health or trigger some kind of damage effect.
        Debug.Log("WalkerEnemy attacks!");
    }
}
