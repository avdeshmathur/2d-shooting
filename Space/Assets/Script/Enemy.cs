using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform player;

    public float movementSpeed = 10f;

    public GameObject particle;

    private float timeBtwShots;
    public float startTimeBtnShots = 5f;

    public Transform firePoint;
    public GameObject enemyBullet;
    public float offset;

    public float stoppingDistance;
    public float retreatDistance;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtnShots;
	}
	
	// Update is called once per frame
	void Update () {

            Vector3 difference = player.position - firePoint.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -movementSpeed * Time.deltaTime);
            }

            if (timeBtwShots <= 0)
            {
                Instantiate(enemyBullet, firePoint.position, Quaternion.identity);
                timeBtwShots = startTimeBtnShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);     
        }
    }
}
