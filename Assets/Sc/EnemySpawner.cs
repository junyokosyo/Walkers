using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyDeta[] _enemy;
    [SerializeField]
    private float _weveTIme;

    [SerializeField]
    private EnemyDeta[] _enemy2;
    [SerializeField]
    private Transform[] _spawnPoint;

    [SerializeField]
    private float _spawnTime = 3f;

    [SerializeField]
    private GameObject _boss;
    [SerializeField]
    private float _bossTime;
    [SerializeField]
    private GameObject _audio;
    [SerializeField]
    private GameObject _bossEfect;

    float _spawnCount = 0f;
    int _allWeightEnemy1;
    int _allWeightEnemy2;
    float _bossCount = 0f;
    bool bos = false;
    float _wevecountTIme = 0f;

    System.Random _random;

    void Start()
    {
        _random = new System.Random();

        // 前半用
        foreach (EnemyDeta enemdata in _enemy)
        {
            _allWeightEnemy1 += enemdata.Weight;
        }

        // 後半用
        foreach (EnemyDeta enemdata in _enemy2)
        {
            _allWeightEnemy2 += enemdata.Weight;
        }
    }

    void Update()
    {
        _wevecountTIme += Time.deltaTime;
        _spawnCount += Time.deltaTime;
        _bossCount += Time.deltaTime;

        if (_spawnCount > _spawnTime && bos == false)
        {
            int spawnPoint = _random.Next(0, _spawnPoint.Length);

            if (_wevecountTIme <= _weveTIme) // 前半
            {
                int randamenemy = _random.Next(1, _allWeightEnemy1);
                foreach (var enemdate in _enemy)
                {
                    randamenemy -= enemdate.Weight;
                    if (randamenemy < 0)
                    {
                        Instantiate(enemdate.EnemyPrefab).transform.position =
                            _spawnPoint[spawnPoint].transform.position;
                        _spawnCount = 0;
                        break;
                    }
                }
            }
            else // 後半
            {
                int randamenemy = _random.Next(1, _allWeightEnemy2);
                foreach (var enemdat in _enemy2)
                {
                    randamenemy -= enemdat.Weight;
                    if (randamenemy < 0)
                    {
                        Instantiate(enemdat.EnemyPrefab).transform.position =
                            _spawnPoint[spawnPoint].transform.position;
                        _spawnCount = 0;
                        break;
                    }
                }
            }
        }

        // ボス出現
        if (_bossCount >= _bossTime && bos == false)
        {
            bos = true;
            _boss.SetActive(true);
            _audio.SetActive(false);
        }
    }
}

[Serializable]
public class EnemyDeta
{
    public GameObject EnemyPrefab;
    public int Weight;
}
