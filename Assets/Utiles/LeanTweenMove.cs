using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.move(gameObject.GetComponent<RectTransform>(), new Vector3(0f, 0f, 0f), 1f).setDelay(1f);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
        
    void LT() 
    {
            
        
    }
}
