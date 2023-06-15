using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawm_Tank_AI : MonoBehaviour
{
    [SerializeField] GameObject tank_AI;
    [SerializeField] GameObject parent_count;

    public int maxEnemies = 10; // S? l??ng k? ??ch t?i ?a có th? xu?t hi?n
    public float spawnDelay = 2f; // Th?i gian ch? gi?a các l?n spawm k? ??ch
    private int currentEnemies = 0; // S? l??ng k? ??ch hi?n t?i
    private bool isSpawning = false;
    // Update is called once per frame

    void Update()
    {
        currentEnemies = parent_count.transform.childCount;
       // Ki?m tra n?u s? l??ng k? ??ch hi?n t?i nh? h?n N thì spawm ti?p
        if (currentEnemies < maxEnemies && !isSpawning)
        {
            StartCoroutine(IE_SpawnEnemy(spawnDelay));
        }

    }

    private void SpawnEnemy()
    {
        // Ki?m tra n?u s? l??ng k? ??ch ?ã ??t t?i ?a thì d?ng spawm
        if (currentEnemies >= maxEnemies) return;

        // Spawm k? ??ch
        Instantiate(tank_AI, transform.position, Quaternion.identity, parent_count.transform);

        // C?p nh?t s? l??ng k? ??ch hi?n t?i
        currentEnemies++;
    }

    IEnumerator IE_SpawnEnemy(float delay)
    {
        isSpawning = true;
        yield return new WaitForSeconds(delay);
        Sound_Manager.instance.PlaySound(SoundType.Spam_Tank);
        SpawnEnemy();
        isSpawning = false;
    }

}
