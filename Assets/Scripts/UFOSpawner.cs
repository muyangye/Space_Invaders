using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    // This script enables UFO to be spawned randomly

    public UFO ufoPrefab;
    private UFO ufo;
    float cooldown = 0.0f;
    public float minCooldown = 10.0f;
    public float maxCooldown = 20.0f;

    void Awake()
    {
        cooldown = Random.Range(minCooldown, maxCooldown);
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0.0f && (!ufo || ufo.destroyed))
        {
            SpawnUFO();
        }
    }

    void SpawnUFO()
    {
        ufo = ufo = Instantiate(ufoPrefab, new Vector3(7.0f, 2.5f, 0.0f), Quaternion.identity);
        cooldown = Random.Range(minCooldown, maxCooldown);
    }
}
