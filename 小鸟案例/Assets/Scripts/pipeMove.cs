using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMove : MonoBehaviour
{
    public float speed;
    public float minRange;
    public float maxRange;
   
    void Start()
    {
        init();


    }
    public float t = 0;
    public void init()
    {
        float y = Random.Range(minRange, maxRange);
        transform.localPosition = new Vector3(0, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position += new Vector3(-speed,0)*Time.deltaTime;
        if (t > 6.8)
        {
            t = 0;
            init();
        }
    }
}
