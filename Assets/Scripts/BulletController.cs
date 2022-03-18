using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 400;

    public void Start()
    {
        Destroy(gameObject, 3f);
    }
    
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        //lower boss health when getting hit
        var gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if ( ! collision.gameObject.CompareTag("Enemy")) {
            return;
        }

        if (gm.bossHealth > 0) {
                gm.bossHealth -= 1;
        }

        Destroy(gameObject);
        }
    }
