﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _TilePrefab;
    private Vector3 _spawnPos;

    private int _round = 1;
    private int _spawns = 0;
    private bool flag = false;
    [SerializeField]
    private GameObject [] _obstacles;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
    IEnumerator SpawnTileRoutine(){
            yield return new WaitForSeconds(0.5f);
            Instantiate(_TilePrefab, _spawnPos, _TilePrefab.transform.rotation);
            _spawnPos.z += 6;
            if (_round % 10 != 0)
                StartCoroutine(SpawnTileRoutine());
            else
            {
                StartCoroutine(SpawnObstacleRoutine());
            }
            _round++;
    }
    */
   


    /*
    IEnumerator SpawnObstacleRoutine()
    {
            yield return new WaitForSeconds(0.5f);
            Instantiate(_TilePrefab, _spawnPos, _TilePrefab.transform.rotation);
            int randomX = Random.Range(0, _obstacles.Length);
            float rand_size = Random.Range(.3f, 1f);
            if (randomX == 0)
            {
                Vector3 newpos = new Vector3(-10f + (rand_size * 3f), 1.52f, _spawnPos.z);
                GameObject obstacle = Instantiate(_obstacles[randomX], newpos, _obstacles[randomX].transform.rotation);
                obstacle.transform.localScale *= rand_size;
                _spawnPos.z += 6;
            }

            if (randomX == 1)
            {
                //_spawnPos.z += 3f;
                flag = true;
                int diff = (int)(rand_size * 10) - 3;
                StartCoroutine(SpawnRingsRoutine(rand_size, diff));
            }


            StartCoroutine(SpawnTileRoutine());
    }

    IEnumerator SpawnRingsRoutine(float size, int diff)
    {
        yield return new WaitForSeconds(0.05f);
        Vector3 newpos = new Vector3(-10f + (size * 3f), 1.5f+(0.15f*diff), _spawnPos.z);
        GameObject obstacle = Instantiate(_obstacles[1], newpos, _obstacles[1].transform.rotation);
        obstacle.transform.localScale *= size;
        _spawnPos.z += 6f;
    }
    */
}
