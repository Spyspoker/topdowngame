using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      public float Health
    {
        set 
        {
           health = value;
           if(health <= 0)
           {
            Defeated();
           }
        }
        get
           {
             return health;
           }
    }
 

    public void Defeated()
    {
        Destroy(gameObject);
    }
}