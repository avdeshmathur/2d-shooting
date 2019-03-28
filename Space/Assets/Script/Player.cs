using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public Rigidbody2D rb;
    private Vector2 moveVelocity;

    public int score = 0;

    public float offset;

    public float movementSpeed = 3f;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public Transform firepoint;
    public GameObject bullet;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused) {

            Time.timeScale = 0f;
        }
        else {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = movement.normalized * movementSpeed;

            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (timeBtwShots <= 0f)
                {
                    Instantiate(bullet, firepoint.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots;
                }
                else
                {
                    timeBtwShots -= Time.fixedDeltaTime;

                }
            }
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyBullet") || collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Scenemanager();
        }
    }

    void Scenemanager()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
