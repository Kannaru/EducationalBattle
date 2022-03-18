
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    //used for calling different script
    public GameObject attack;
    private AttackPlayer _whichAttack;

    public float moveSpeed = 400;


    //where to move towards
    public Vector3 moveDirection;
    public Vector3 moveDirectionOnEnemy;

    public PlayerController target;
    public GameObject target2;
    private Rigidbody _rb;

    public int aimX;

    public bool attack1;
    public bool attack2;
    public bool attack3;

    public bool gotHit;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        target = FindObjectOfType<PlayerController>();
        target2 = GameObject.FindGameObjectWithTag("Enemy");
        _whichAttack = attack.GetComponent<AttackPlayer>();

        //base velocity
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        _rb.velocity = new Vector3(moveDirection.x, 0, moveDirection.z);
        Destroy(gameObject, 2f);


        if (_whichAttack.attack2) {
            Destroy(gameObject, 5f);
        }
    }


    void Update()
    {
        //update movement each frame to go towards the enemy and not player on attack 3
        if (attack3) {
            moveDirectionOnEnemy = (target2.transform.position - transform.position).normalized * moveSpeed;
            _rb.velocity = new Vector3(moveDirectionOnEnemy.x, 0, moveDirectionOnEnemy.z);
        }
    }

    //only activate attack 1
    public void Attack1Active()
    {
        attack1 = true;
        attack2 = false;
        attack3 = false;
    }

    //only activate attack 2
    public void Attack2Active()
    {
        attack1 = false;
        attack2 = true;
        attack3 = false;
    }

    //only activate attack 3
    public void Attack3Active()
    {
        attack1 = false;
        attack2 = false;
        attack3 = true;
    }


    public void OnCollisionEnter(Collision collision)
    {
        //destroy when hits a player bullet or it hits the enemy
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Enemy")) {
            Destroy(gameObject);
        }
        //remove hp when player hit
        else if (collision.gameObject.CompareTag("Player")) {
            var gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            if (gm.health > 0) {
                gm.health -= 1; gm.score -= 2000;
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && gotHit) {
            Destroy(gameObject);
            gotHit = false;
        }
    }
}