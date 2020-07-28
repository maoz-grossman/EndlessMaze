﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * player: 0. singleton. 
           1.Movement:
           2.Items:  
powerUps: _1. scaleup 
	    2. scaleDown
 	   3. coins
	   4.fruit(optional)
obstical: 
area:
spawner: _powerUp.
   	_obstical.
  	_tiles.
             */
public class TileBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _TilePrefab;
    private Vector3 _spawnPos;
    public float Player_speed=3f;
    private CharacterController _controller;
    private float _gravity = 9.807f;
    [SerializeField]
    private Transform trr;
    [SerializeField]
    private float _scaleUp = 1;
    [SerializeField]
    private float _scaleDown =1;
    private int _round = 1;

    [SerializeField]
    private GameObject[] _obstacles;

    private Animator _anim;
    void Start()
    {
        _spawnPos.z += 150;
        _spawnPos.y += 17.254f;
        _spawnPos.x += 5.896f;
        //_controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
        //transform.position += new Vector3(1.59f, 0, 4.600567f);

    }

    void FixedUpdate()
    {
       // Movement();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tile")
        {
            MakeTile();
        }
        else if(other.tag == "Arc")
        {
            MakeTile();
        }
        else if (other.tag == "End")
        {
            Destroy(other.transform.parent.parent.gameObject, 0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Arc")
        Destroy(other.gameObject, 0.2f);
    }
    /*
    private void Movement()
    {
        bool flag = false;
        Vector3 direction = new Vector3(0, 0, 1);
        Vector3 velocity = direction * Player_speed;
        
        if (!_controller.isGrounded)
        {
            velocity.y -= _gravity;
        }
        
        float x = 0f;
        if (Input.GetKeyDown(KeyCode.A) &&transform.position.x>-1.3f)
        {
            flag = true;
            x= -1.8f;
        }

        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 4.7f)
        {
            flag = true;
            x= 1.8f;
        }

        if (!flag)
        {
            //_controller.Move(velocity * Time.deltaTime);
            trr.Translate(velocity * Time.deltaTime);
        }
        else
            trr.Translate(new Vector3(x, 0, 10 * Time.deltaTime));
       // _controller.Move(new Vector3(x,0,10*Time.deltaTime));
    }
    */
    private void MakeTile()
    {
        int randomX = Random.Range(0, _obstacles.Length - 1);
        if (!(_round % 3 == 0 && randomX != 0))
        {
            GameObject temp = Instantiate(_TilePrefab, _spawnPos, _TilePrefab.transform.rotation);
            _spawnPos.z += 60;
            _spawnPos.x = temp.transform.position.x;
            _spawnPos.y = temp.transform.position.y;
        }
        if (_round % 3 == 0)
        {
            if (randomX == 0 || randomX == 1)
            {
                float rand_size = Random.Range(.1f, .5f);
                if (randomX == 0)
                {
                    float diff1 = (0.275f * ((rand_size * 10f) - 3f));
                    float diff2 = (0.15f * ((rand_size * 10f) - 3f));
                    Vector3 newpos = new Vector3(2.6323f + diff1, 0.55271f + diff2, _spawnPos.z);
                    GameObject obstacle = Instantiate(_obstacles[randomX], newpos, _obstacles[randomX].transform.rotation);
                    obstacle.transform.localScale *= rand_size;
                }
                else
                {
                    float diff1 = (0.275f * ((rand_size * 10f) - 3f));
                    float diff2 = (0.15f * ((rand_size * 10f) - 3f));
                    _spawnPos.z += 9;
                    for (int i = 0; i <= 5; i++)
                    {
                        Vector3 newpos = new Vector3(1.91f + diff1, 0.47f + diff2, _spawnPos.z + i * 5);
                        GameObject obstacle = Instantiate(_obstacles[randomX], newpos, _obstacles[randomX].transform.rotation);
                        obstacle.transform.localScale *= rand_size;
                    }

                    _spawnPos.z += 25;
                }
            }

            else
            {
                if (randomX == 2)
                {
                    Instantiate(_obstacles[randomX], _spawnPos, _obstacles[randomX].transform.rotation);
                    int i = Random.Range(1, 5);
                    _spawnPos.z += (3 * i);
                }
                else
                {

                }
            }

        }
        _round++;
    }
    
}
