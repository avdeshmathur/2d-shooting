using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{

    public Transform player;

    public int health = 3;
    public float movementSpeed = 3f;
    public float rotationSpeed = 700f;

    public GameObject particlemin;
    public GameObject particle;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 difference = player.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        transform.position = Vector2.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            health--;

            if (health >= 1)
            {
                Instantiate(particlemin, transform.position, Quaternion.identity);
            }
            if (health <= 0)
            {
                Destroy(gameObject);
                Instantiate(particle, transform.position, Quaternion.identity);
                Score.score += 2;
            }
        }
    }
}