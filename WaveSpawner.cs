﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
	public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public int scoreValue = 1;
    public Transform[] spawnPoints;
    public GME gme;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountDown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("NO spawn points refereneed");
        }

        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {

        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave( waves[nextWave]));
            }
            
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }


    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            DestroyObject(GameObject.FindGameObjectWithTag("SPAWNER"), 1f);
            DestroyObject(GameObject.FindGameObjectWithTag("Spawners"), 2f);
            Spawn.spawners -= scoreValue;
            nextWave = 0;
            //gme.WinLevel();
        }
        else
        {
            nextWave++;
        }

        

    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }


    IEnumerator SpawnWave (Wave _wave)
    {
        Debug.Log("Spawning Wave" + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i <_wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;

    }

    void SpawnEnemy (Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
        Debug.Log("Spawning Enemy" + _enemy.name);
    }

}
