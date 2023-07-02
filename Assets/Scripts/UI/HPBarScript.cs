using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarScript : MonoBehaviour
{

    public Transform bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(int current, int max)
    {
        float state = (float)current;
        state /= max;
        if(state < 0f)
        {
            state = 0f;
        }
        bar.transform.localScale = new Vector3(state, 1f, 1f);
        Debug.Log("HP Bar was changed");
    
    }
}
