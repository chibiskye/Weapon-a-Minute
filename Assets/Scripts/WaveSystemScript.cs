using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystemScript : MonoBehaviour
{
    [SerializeField] private GameObject gSwordEnemy = null;
    [SerializeField] private GameObject gGunEnemy = null;
    [SerializeField] private GameObject fSwordEnemy = null;
    private int waveNumber;
    private List<GameObject> enemySet;
    private List<GameObject>  activeEnemies;
    // Start is called before the first frame update
    void Start()
    {
        enemySet = new List<GameObject>();
        activeEnemies = new List<GameObject>();
        waveNumber = 0;
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
        Debug.Log("Wave" + waveNumber);
        waveNumber++;
        GameObject enemy;
        Vector3[] positions = {new Vector3(-18.17953f, 1f, -0.114f), new Vector3(4.3f, 1f, 44.2f), new Vector3(4.3f, 1f, -44.2f)};
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        int i;
        switch(waveNumber)
        {
            case 1: 
                enemySet.Clear();
                
                
                for (i = 0; i < 3; i++) {
                    enemy = Instantiate(gSwordEnemy, positions[i], rotation);
                    enemy.SetActive(false);
                    enemySet.Add(enemy);
                } break;
            case 2:
                
                enemySet.Clear();
                for (i = 0; i < 2; i++) {
                    enemy = Instantiate(gGunEnemy, positions[i], rotation);
                    enemy.SetActive(false);
                    enemySet.Add(enemy);
                } 
                enemy = Instantiate(gSwordEnemy, positions[i], rotation);
                enemy.SetActive(false);
                enemySet.Add(enemy);
                break;
            default: enemySet.Clear(); Debug.Log("First wave complete"); break;
        }

        foreach (GameObject e in enemySet)
        {
            GameObject newEnemy = Instantiate(e);
            newEnemy.SetActive(true);
            activeEnemies.Add(newEnemy);
        }
    }


}
