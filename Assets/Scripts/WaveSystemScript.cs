using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystemScript : MonoBehaviour
{
    [SerializeField] private GameObject gSwordEnemy = null; // prefab
    [SerializeField] private GameObject gGunEnemy = null;
    [SerializeField] private GameObject fSwordEnemy = null;
    [SerializeField] private Vector3[] positions = null;

    enum EnemyType
    {
        gSword = 10,
        gGun = 20,
        fSword = 50
    }

    private InfoDisplayScript infoDisplay = null;
    private List<GameObject> enemySet;
    private Dictionary<GameObject, EnemyType> activeEnemies;
    private Quaternion rotation;
    private int positionIndex;
    private int waveNumber;

    // Start is called before the first frame update
    void Start()
    {
        infoDisplay = GameObject.FindWithTag("PlayerScreen").GetComponentInChildren<InfoDisplayScript>();
        activeEnemies = new Dictionary<GameObject, EnemyType>();
        enemySet = new List<GameObject>();

        waveNumber = 0;
        rotation = Quaternion.Euler(new Vector3(0, 90, 0));
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        foreach (var entry in activeEnemies)
        {
            GameObject enemy = entry.Key;
            if (!enemy.activeSelf)
            {
                int points = (int)entry.Value;
                PlayerController.PlayerScore += points;
                infoDisplay.DisplayScore(PlayerController.PlayerScore);

                activeEnemies.Remove(enemy);
                Destroy(enemy.gameObject);
            }
        }

        if (activeEnemies.Count == 0)
        {
            StartNextWave();
        }
    }

    void StartNextWave()
    {
        waveNumber++;
        // Debug.Log("Wave" + waveNumber);

        if (infoDisplay != null)
        {
            infoDisplay.DisplayWave(waveNumber);
        }

        // GameObject enemy;
        int i = 0;
        switch(waveNumber)
        {
            case 1: 
                // enemySet.Clear();
                for (i = 0; i < 3; i++) {
                    // enemySet.Add(CreateEnemy(EnemyType.gSword, i));
                    activeEnemies.Add(CreateEnemy(EnemyType.gSword, i), EnemyType.gSword);
                } break;
            case 2:
                enemySet.Clear();
                for (i = 0; i < 2; i++) {
                    // enemySet.Add(CreateEnemy(EnemyType.gGun, i));
                    activeEnemies.Add(CreateEnemy(EnemyType.gGun, i), EnemyType.gGun);
                }
                // enemySet.Add(CreateEnemy(EnemyType.gSword, i));
                activeEnemies.Add(CreateEnemy(EnemyType.gSword, i), EnemyType.gSword);
                break;
            case 3:
                enemySet.Clear();
                // enemySet.Add(CreateEnemy(EnemyType.fSword, 0));
                activeEnemies.Add(CreateEnemy(EnemyType.fSword, 0), EnemyType.fSword);
                break;
            case 4:
                enemySet.Clear();
                for (i = 0; i < 2; i++) {
                    // enemySet.Add(CreateEnemy(EnemyType.gSword, i));
                    activeEnemies.Add(CreateEnemy(EnemyType.gSword, i), EnemyType.gSword);
                }
                // enemySet.Add(CreateEnemy(EnemyType.gGun, i));
                activeEnemies.Add(CreateEnemy(EnemyType.gGun, i), EnemyType.gGun);
                break;

            default: 
                int post4WaveNum = waveNumber - 4;
                i++;
                if (i <= positions.Length) {
                    i = 0;
                }
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

                foreach (GameObject e in enemySet)
                {
                    GameObject newEnemy = Instantiate(e);
                    newEnemy.SetActive(true);
                    activeEnemies.Add(newEnemy, EnemyType.gSword); // TODO: apply proper enum values to enemies after Wave4
                }
                return;
        }

        foreach (GameObject enemy in activeEnemies.Keys)
        {
            enemy.SetActive(true);
        }
    }

    GameObject CreateEnemy(EnemyType type, int posIndex)
    {
        GameObject enemy;
        switch(type)
        {
            case EnemyType.gSword: enemy = Instantiate(gSwordEnemy, GetPosition(posIndex, false), rotation, this.transform); break;
            case EnemyType.gGun: enemy = Instantiate(gGunEnemy, GetPosition(posIndex, false), rotation, this.transform); break;
            case EnemyType.fSword: enemy = Instantiate(fSwordEnemy, GetPosition(posIndex, true), rotation, this.transform); break;
            default: enemy = Instantiate(gSwordEnemy, GetPosition(posIndex, false), rotation, this.transform); break;
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
