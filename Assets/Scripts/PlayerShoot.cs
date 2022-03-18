using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //behaviour of the bullets
    public bool isFire;
    public float timeBetweenBullets;
    public float attackSpeed;

    //bullets
    private AudioSource _source;
    public GameObject bulletPrefab;
    public BulletController bullet;
    public Transform firePoint;


    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

   private void Update()
    {
        var gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //shoot if space bar is held
        if (Input.GetKeyDown(KeyCode.Space) && gm.gameActive) {
            isFire = true;
        }

        //stop shooting if left mouse button is released
        if (Input.GetKeyUp(KeyCode.Space)) {
            isFire = false;
        }

        //fire the bullets
        if (!isFire) {
            return;
        }

        attackSpeed -= Time.deltaTime;
        if (attackSpeed > 0) {
            return;
        }

        attackSpeed = timeBetweenBullets;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        _source.Play();
    }
}