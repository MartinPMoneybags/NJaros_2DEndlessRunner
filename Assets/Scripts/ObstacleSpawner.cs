using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstaclePrefabs = new List<GameObject>();
    [SerializeField] private float obstacleSpeed = 3f;

    [SerializeField] private float spawnTimeMin = 2f;
    [SerializeField] private float spawnTimeMax = 5f;

    private float timeUntilObstacleSpawn; // This is the number that counts up
    public float obstacleSpawnTime = 2f; // This is when we spawn an object
    public float killLimit = -40f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            Spawn();
        }

        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if(timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
            Spawn();
            obstacleSpawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            timeUntilObstacleSpawn = 0;
        }
    }

    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();

        obstacleRB.velocity = Vector2.left * obstacleSpeed;

        if(transform.position.x >= killLimit)
        {
            Destroy(this.gameObject);
        }

    }
}
