using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 32f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Player player;
    private Vector3 lastEndPosition;

      private void Awake()
      {
          lastEndPosition = levelPart_Start.Find("EndPosition").position;
          SpawnLevelPart();
          //Preload a level part

      }

       void Update()
      {
          if(Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
          {

              SpawnLevelPart();
              //Debug.Log("hi");
          }


      }

      private void SpawnLevelPart()
      {
          Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
          Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
          lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
      }
      private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
      {
          Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
          return levelPartTransform;
      }

     
} 
