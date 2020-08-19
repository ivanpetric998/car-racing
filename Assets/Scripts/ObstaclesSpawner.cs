using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
  public GameObject[] prepreke; 
  public GameObject[] trake;
  public float minSpawnTime, maxSpawnTime; 
  [SerializeField] private float timeToW8;
  void Start()
  {
    StartCoroutine("Spawn");
  }
  IEnumerator Spawn() 
  {
    yield return new WaitForSeconds(timeToW8);

    while (!GameManager.instance.gameOver)
    {
      MakeObsticle();
      yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime)); 
    }
  }
  void MakeObsticle()
  {
    int rand = Random.Range(0, prepreke.Length);
    int rand2 = Random.Range(0, trake.Length);
    Instantiate(prepreke[rand], trake[rand2].transform.position, Quaternion.identity); 
  }
}

