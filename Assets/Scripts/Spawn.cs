using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
  public GameObject spawnObj;

  public int maxEnemy, amountEnemy;
  public float minX, maxX, minZ, maxZ, minSpawnTime, maxSpawnTime;
  private bool isSpawning;

  private float timer;

  // !Is spawn ska vara False från 1-frame
  void Awake()
  {
    isSpawning = false;
  }
  void Update()
  {
    // !Ger en liten random delay efter varje Spawn
    if (!isSpawning)
    {
      timer = Random.Range(minSpawnTime, maxSpawnTime);
      Invoke("SpawnObject", timer);
      isSpawning = true;
    }
  }
  void SpawnObject()
  {
    // !Spawnar fienden i Random plats
    float x = Random.Range(minX, maxX);
    float z = Random.Range(minZ, maxZ);

    Instantiate(spawnObj, new Vector3(x, 5, z), Quaternion.identity);
    amountEnemy += 1;
    isSpawning = false;

  }
}
