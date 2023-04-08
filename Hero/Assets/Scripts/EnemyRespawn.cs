using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyRespawn : MonoBehaviour
{
    public Enemy enemyScript;

    public int energy = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collide) {
        
        if(collide.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            enemyScript.DestoryEnemies();
            enemyScript.SpawnEnemies();
        }
        else if(collide.gameObject.CompareTag("Egg"))
        {
            energy -= 25;
            Color decreaseColor = GetComponent<SpriteRenderer>().color;
            decreaseColor.a =  energy * 0.008f;
            GetComponent<SpriteRenderer>().color = decreaseColor;

            if(energy <= 0)
            {
                Destroy(this.gameObject);
                enemyScript.DestoryEnemies();
                enemyScript.SpawnEnemies();
                //update UI with the right total destroyed display
            }
        }
    }
}
