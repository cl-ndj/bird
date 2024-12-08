using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ziDan : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        if (Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(transform.position))==false)
        {
            Destroy(this.gameObject,1f);
        }
    }
}
