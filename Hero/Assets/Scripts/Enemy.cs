using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    
    public GameObject enemyPrefab;
    public int destoryedEnemies = 0;
    public TextMeshProUGUI heroTouchingText;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i ++)
        {
            SpawnEnemies();
        }
    }


    public void SpawnEnemies() {

        GameObject reEnemy = Instantiate(enemyPrefab);
        reEnemy.GetComponent<EnemyRespawn>().enemyScript = this;

        float maxY = ((Camera.main.orthographicSize) * 0.9f);
        float maxX = ((Camera.main.orthographicSize) * Camera.main.aspect) * 0.9f;
        float enemyX = Random.Range(-maxX, maxX);
        float enemyY = Random.Range(-maxY, maxY);

        reEnemy.transform.position = new Vector3(enemyX, enemyY, 0f);
    }

    public void DestoryEnemies() 
    {
        destoryedEnemies++;
        heroTouchingText.text = "Enemy: Count(10) Destroyed(" + destoryedEnemies + ")";
    }
}
