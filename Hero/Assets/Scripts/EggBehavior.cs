using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{

    public Hero heroScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) { 
        if (col.gameObject.tag.Equals("Enemy")) {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(this.gameObject);
        heroScript.decreaseEggCount();
    }
}
