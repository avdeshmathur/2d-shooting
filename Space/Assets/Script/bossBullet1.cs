using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet1 : MonoBehaviour
{
    public Transform player;

    private float bulletSpeed = 8f;
    private float lifeTime = 2f;
    private float offset = 90f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke("Destroy", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, bulletSpeed * Time.deltaTime);

        Vector3 difference = player.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }
}