using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SpawnManager : MonoBehaviour
{
    private GameObject player;
    public GameObject catGO;
    public GameObject dogGO;
    public GameObject CatNipGO;

    private float spawnArea = 12;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating("SpawnCatRandomPos", 1, 3);
        InvokeRepeating("SpawnDogRandomPos", 10, 5);
        InvokeRepeating("SpawnCatNipRandomPos", 1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCatRandomPos()
    {
        SpawnAtRandomPos(catGO);
    }

    void SpawnDogRandomPos()
    {
        SpawnAtRandomPos(dogGO);
    }

    void SpawnCatNipRandomPos()
    {
        SpawnAtRandomPos(CatNipGO);
    }

    void SpawnAtRandomPos(GameObject obj)
    {
        Vector3 randomPos = new Vector3(Random.Range(-spawnArea, spawnArea), 0.1f, Random.Range(-spawnArea, spawnArea));
        Vector3 lookAtPlayer = player.transform.position - randomPos;
        Instantiate(obj, randomPos, obj.transform.rotation);
    }
}
