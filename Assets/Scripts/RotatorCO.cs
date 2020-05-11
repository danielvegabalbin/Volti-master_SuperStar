using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorCO : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(0, rotationSpeed, 0);

        
    }
}
