using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public float maxRotationSpeed = 150f;
    public float minRotationSpeed = 100f;

    private float timeBtwShots = 1f;
    private float startTimeBtnShots = .7f;

    public float minTimeToRotate = 5f;
    public float startRotationTime = 5f;

    public GameObject bullet;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (minTimeToRotate <= 2f)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * maxRotationSpeed);
            minTimeToRotate -= Time.deltaTime;

            if (minTimeToRotate <= 0f)
            {
                minTimeToRotate = startRotationTime;
            }
        }
        else
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * minRotationSpeed);
            minTimeToRotate -= Time.deltaTime;
        }
        if (timeBtwShots <= .1)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);

            if (timeBtwShots <= 0){
                timeBtwShots = startTimeBtnShots;
            }
            timeBtwShots = startTimeBtnShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
