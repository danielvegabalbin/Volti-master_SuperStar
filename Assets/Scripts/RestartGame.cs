using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] Transform startPosition;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        startPosition.position = new Vector3(0.0f, 28.5f, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartPlayerPosition() 
    {
        Time.timeScale = 1;
        player.transform.position =new Vector3(0.0f,28.5f,5f) ;

    }
}
