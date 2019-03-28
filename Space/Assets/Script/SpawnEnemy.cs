using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject[] enemy;
    public float spawnTime = 3f;
    public float spawnTimeRepeat = 3f;
    public float decreaseTime = .5f;
    public float minTime = .5f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTimeRepeat);
    }
	

	void Spawn () {
        int randomSpawn = Random.Range(0, spawnPoints.Length);
        int randonEne = Random.Range(0, enemy.Length);

        Instantiate(enemy[randonEne], spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);
        if (spawnTimeRepeat > minTime)
        {
            spawnTimeRepeat -= decreaseTime;
        }
    }
}
