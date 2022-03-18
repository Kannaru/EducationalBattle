using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public GameObject bullets;
    private EnemyBulletController _control;
    public bool gameActiveBool;

    public Transform shootingPoint;
    public GameObject bullet;

    public bool attack1;
    public float fireRateAttack1;
    public float nextFireAttack1;

    public bool attack2;
    public float fireRateAttack2;
    public float nextFireAttack2;

    public bool attack3;
    public float fireRateAttack3;
    public float nextFireAttack3;
    private float _attack3Axis;
    private Vector3 _randomSpawnLocation;


    private void Start()
    {
        _control = bullets.GetComponent<EnemyBulletController>();
        fireRateAttack1 = 1f;
        nextFireAttack1 = Time.time;
        fireRateAttack2 = 0.3f;
        nextFireAttack2 = Time.time;
        fireRateAttack3 = 0.3f;
        nextFireAttack3 = Time.time;
        attack1 = false;
        attack2 = false;
        attack3 = false;
    }

   private void Update()
    {
        CheckIfTimeToFire();
        //randomize spawn pos enemy bullet with attack 3
        _attack3Axis = Random.Range(-300, 300);
        _randomSpawnLocation = new Vector3(_attack3Axis, 7, -300);
    }


    private void CheckIfTimeToFire()
    {
        var gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (!gameActiveBool) {
            gm.gameActive = true;
            gameActiveBool = true;
        }

        //attack1
        if (Time.time > nextFireAttack1 && attack1) {
            attack2 = false;
            attack3 = false;
            //shoot 5 bullets close to each other
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            _control.aimX = 130;
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            _control.aimX = 80;
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            _control.aimX = -80;
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            _control.aimX = -130;
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            _control.aimX = 0;
            _control.Attack1Active();

            nextFireAttack1 = Time.time + fireRateAttack1;
        }
        //attack2
        else if (Time.time > nextFireAttack2 && attack2) {
            attack1 = false;
            attack3 = false;
            
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            nextFireAttack2 = Time.time + fireRateAttack2;
            _control.Attack2Active();
        }
        //attack3
        else if (Time.time > nextFireAttack3 && attack3) {
            attack1 = false;
            attack2 = false;
            Instantiate(bullet, _randomSpawnLocation, Quaternion.identity);
            nextFireAttack3 = Time.time + fireRateAttack3;
            _control.Attack3Active();
        }
    }
}