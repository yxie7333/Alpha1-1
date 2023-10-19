using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gridmanager : MonoBehaviour
{
    public static Gridmanager instance;
    public List<Grid> allgrids;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPutRight(Grid g)
    {
        allgrids.Remove(g);
        if (allgrids.Count == 0)
        {
            Debug.Log("Win!");
        }
    }
}
