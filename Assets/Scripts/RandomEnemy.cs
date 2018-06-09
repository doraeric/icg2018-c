using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemy : MonoBehaviour
{

    // Use this for initialization
    public Transform[] cubepoints;
    public float spawntime = 1.0f;
    public GameObject cubeturrent;
    public float spawnRatePerSec =0.2f;
   // int[] cubeindexuse = new int[10];
   // static int indexnumber = 0;
    void Start()
    {
        InvokeRepeating("RandomItems", spawntime, spawntime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RandomItems()
    {
        int cubeindex = Random.Range(0, cubepoints.Length);
        if (Random.value < spawnRatePerSec)
        {
            Instantiate(cubeturrent, cubepoints[cubeindex].position + Random.Range(-3, 3)
               * Vector3.right + Random.Range(-3, 3) * Vector3.forward, cubepoints[cubeindex].rotation);
        }
        
        /*bool a = true;
        
        for(int i  = 0; i < cubeindexuse.Length ; i++)
        {
            if (cubeindex == cubeindexuse[i])
                a = false;
        }
        
        if ( a == true)
        {
            cubeindexuse[indexnumber] = cubeindex;
            indexnumber++;
            Instantiate(cubeturrent, cubepoints[cubeindex - 1].position + Random.Range(-5, 5)
                * Vector3.right + Random.Range(-5, 5) * Vector3.forward, cubepoints[cubeindex].rotation);
        }同個位置不重複生成 */


    }
}