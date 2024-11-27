using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineManager : MonoBehaviour
{
    public GameObject pipe;
    public float s;
    List<pipeMove> piplines = new List<pipeMove>();
    void Start()
    {

    }

    void Update()
    {
        
    }
    Coroutine Coroutine = null;
    public void init()
    {
        for (int i = 0; i < piplines.Count; i++)
        {
            Destroy(piplines[i].gameObject);
        }
        piplines.Clear();
    }
    public void pileStart()
    {
        
        Coroutine= StartCoroutine(GenerationPipes());
       
    }
    public void pileStop()
    {
        for (int i = 0; i < piplines.Count; i++)
        {
            piplines[i].enabled = false;
            if (piplines.Count>0)
            {
                StopCoroutine(Coroutine);
            }
        }
       
       
    }
    IEnumerator GenerationPipes()
    {
        for (int i = 0; i < 3; i++)
        {
            if(piplines.Count<3)
            GenerationPipe();
            else
            {
                piplines[i].enabled = true;
                piplines[i].init();
            }
            yield return new WaitForSeconds(s);
        }
        
    }
    void GenerationPipe()
    {
        if (piplines.Count<3)
        {
            GameObject obj = Instantiate(pipe, this.transform);
            pipeMove p = obj.GetComponent<pipeMove>();
            piplines.Add(p);
        }
      

       

    }
}
