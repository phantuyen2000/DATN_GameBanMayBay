using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] WaveConfig boss;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;
    [Header("MORE POWER!!!")]
    [SerializeField] float bonusHp = 100f;
    [SerializeField] float attackFaster = 0.2f;
    int enemyAlive = 0;
    float bonusHealth = 0f;
    IEnumerator Start()
    {
        bonusHealth = 0f;
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
            yield return new WaitUntil(() => enemyAlive <= 0);
            yield return new WaitForSeconds(3);
            yield return StartCoroutine(SpawnBoss(boss));
            yield return new WaitUntil(() => enemyAlive <= 0);
            looping = true;
            bonusHealth += bonusHp;
        } while (looping);
        
    }
    public void EnemyAppear()
    {
        enemyAlive++;
    }
    public void EnemyKilled()
    {
        enemyAlive--;
    }
    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex<waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            looping = false;
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
            waveConfig.GetEnemyPrefab(),
            waveConfig.GetWaypoints()[0].transform.position,
            Quaternion.identity);
            newEnemy.GetComponent<Enemy>().StrongerOverTime(bonusHealth, attackFaster);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
    IEnumerator SpawnBoss(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
            waveConfig.GetEnemyPrefab(),
            waveConfig.GetWaypoints()[0].transform.position,
            Quaternion.identity);
            newEnemy.GetComponent<Enemy>().StrongerOverTime(bonusHealth*100, attackFaster);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}