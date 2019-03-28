using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpeed : MonoBehaviour {

    public float bulletspeed = 10f;
    private float lifeTime = .75f;
    public GameObject particle;
    public GameObject particleMin;

    private void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    private void Update() {
       
          transform.Translate(Vector2.up * bulletspeed * Time.deltaTime);
       }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Score.score++;
        }
        else if (collision.CompareTag("EnemyHex"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
            Instantiate(particle, transform.position, Quaternion.identity);
        }
        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
            Instantiate(particleMin, transform.position, Quaternion.identity);
        }
    }
}
