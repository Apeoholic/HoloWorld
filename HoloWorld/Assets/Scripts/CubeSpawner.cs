using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour
{

    public float force = 200;
    bool isSpawning = false;
    public float minTime = 1f;
    public float maxTime = 3f;
    public GameObject[] enemies;  // Array of enemy prefabs.

    IEnumerator SpawnObject(int index, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        var enemy=Instantiate(enemies[index], transform.position, transform.rotation) as GameObject;
        enemy.GetComponent<Rigidbody>().AddForce(transform.up * (force*Random.Range(0.8f,1)));
        //We've spawned, so now we could start another spawn     
        isSpawning = false;
    }

    void Update()
    {
        //We only want to spawn one at a time, so make sure we're not already making that call
        if (!isSpawning)
        {
            isSpawning = true; //Yep, we're going to spawn
            int enemyIndex = Random.Range(0, enemies.Length);
            StartCoroutine(SpawnObject(enemyIndex, Random.Range(minTime, maxTime)));
        }
    }
}
