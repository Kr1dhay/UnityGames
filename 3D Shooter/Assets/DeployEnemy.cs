using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int xPos;
    public int zPos;
    public EnemyScript EnemyScript;


    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

   IEnumerator EnemyDrop()
    {
        while (0 == 0) //EnemyScript.health < 0
        {
            xPos = Random.Range(-40, 65);
            zPos = Random.Range(-18, 25);
            Instantiate(enemyPrefab, new Vector3(xPos, 4, zPos), Quaternion.identity);
            Debug.Log("Spawned");
            yield return new WaitForSeconds(Random.Range(0.5f, 5f));
        }
    }
    
}
