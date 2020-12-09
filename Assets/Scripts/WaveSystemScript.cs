using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystemScript : MonoBehaviour
{
    [SerializeField] private GameObject gSwordEnemy = null;
    [SerializeField] private GameObject gGunEnemy = null;
    [SerializeField] private GameObject fSwordEnemy = null;
    [SerializeField] private Vector3[] positions = null;
    private int waveNumber;
    private int positionIndex;
    private List<GameObject> enemySet;
    private List<GameObject>  activeEnemies;
    private Quaternion rotation;

    enum EnemyType
    {
        gSword,
        gGun,
        fSword
    }
    // Start is called before the first frame update
    void Start()
    {
        enemySet = new List<GameObject>();
        activeEnemies = new List<GameObject>();
        waveNumber = 0;
        rotation = Quaternion.Euler(new Vector3(0, 90, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (GameObject enemy in activeEnemies)
        {
            if (!enemy.active)
            {
                activeEnemies.Remove(enemy);
            }
        }

        if (activeEnemies.Count == 0f)
        {
            StartNextWave();
        }
    }

    void StartNextWave()
    {
        waveNumber++;
        Debug.Log("Wave" + waveNumber);
        GameObject enemy;
        int i = 0;
        switch(waveNumber)
        {
            case 1: 
                enemySet.Clear();
                for (i = 0; i < 3; i++) {
                    enemySet.Add(CreateEnemy(EnemyType.gSword, i));
                } break;
            case 2:
                enemySet.Clear();
                for (i = 0; i < 2; i++) {
                    enemySet.Add(CreateEnemy(EnemyType.gGun, i));
                }
                enemySet.Add(CreateEnemy(EnemyType.gSword, i));
                break;
            case 3:
                enemySet.Clear();
                enemySet.Add(CreateEnemy(EnemyType.fSword, 0));
                break;
            case 4:
                enemySet.Clear();
                for (i = 0; i < 2; i++) {
                    enemySet.Add(CreateEnemy(EnemyType.gSword, i));
                }
                enemySet.Add(CreateEnemy(EnemyType.gGun, i));
                break;
            
            default: 
                int post4WaveNum = waveNumber - 4;
                i++;
                if (post4WaveNum % 5 == 0) 
                {
                    enemySet.Add(CreateEnemy(EnemyType.fSword, i));
                }
                else if (post4WaveNum % 2 == 0)
                {
                    enemySet.Add(CreateEnemy(EnemyType.gGun, i));
                }
                else
                {
                    enemySet.Add(CreateEnemy(EnemyType.gSword, i));
                }
                break;
        }

        foreach (GameObject e in enemySet)
        {
            GameObject newEnemy = Instantiate(e);
            newEnemy.SetActive(true);
            activeEnemies.Add(newEnemy);
        }
    }

    GameObject CreateEnemy(EnemyType type, int posIndex)
    {
        GameObject enemy;
        switch(type)
        {
            case EnemyType.gSword: enemy = Instantiate(gSwordEnemy, GetPosition(posIndex, false), rotation); break;
            case EnemyType.gGun: enemy = Instantiate(gGunEnemy, GetPosition(posIndex, false), rotation); break;
            case EnemyType.fSword: enemy = Instantiate(fSwordEnemy, GetPosition(posIndex, true), rotation); break;
            default: enemy = Instantiate(gSwordEnemy, GetPosition(posIndex, false), rotation); break;
        }
        enemy.SetActive(false);
        return enemy;
    }

    Vector3 GetPosition(int index, bool isFlying)
    {
        if(isFlying)
        {
            return new Vector3(positions[index].x, 2f, positions[index].z);
        }
        else
        {
            return new Vector3(positions[index].x, 1f, positions[index].z);
        }
    }


}
