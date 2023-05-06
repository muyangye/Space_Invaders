using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    // This script enables UFO to be spawned randomly

    public UFO ufoPrefab;
    private UFO ufo;
    private float cooldown = 0.0f;
    public float minCooldown = 10.0f;
    public float maxCooldown = 20.0f;
    private Vector3 spawnPos = new Vector3(7.0f, 2.5f, 0.0f);

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
        ufo = ufo = Instantiate(ufoPrefab, spawnPos, Quaternion.identity);
        cooldown = Random.Range(minCooldown, maxCooldown);
    }
}
