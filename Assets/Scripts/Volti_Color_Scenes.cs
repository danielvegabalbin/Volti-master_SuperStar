using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volti_Color_Scenes : MonoBehaviour
{
    [SerializeField] GameObject player_Circle;
    [SerializeField] GameObject player_Particles;
    [SerializeField] GameObject player_ElectricBeam;
    [SerializeField] TrailRenderer myTrailRenderer;
    [SerializeField] Material BeamMT;
    [SerializeField] GameObject[] imagesColor;
    [SerializeField] Color[] colorsArray;
    

    ParticleSystem circlePS;
    ParticleSystem particlesPS;
    ParticleSystem electricBeamPS;
    
    int colorPosition = 0;
    

   
    private void Awake()
    {
        circlePS = player_Circle.GetComponent<ParticleSystem>();
        particlesPS = player_Particles.GetComponent<ParticleSystem>();
        electricBeamPS = player_ElectricBeam.GetComponent<ParticleSystem>();
        TrailRenderer myTrailRenderer = GetComponent<TrailRenderer>();
       

        if (!PlayerPrefs.HasKey("colorPosition"))
        {
            PlayerPrefs.SetInt("colorPosition", 0);
            colorPosition = PlayerPrefs.GetInt("colorPosition");
            ChangeColor(colorPosition);
        }
        if (PlayerPrefs.HasKey("colorPosition"))
        {
            colorPosition = PlayerPrefs.GetInt("colorPosition");
            ChangeColor(colorPosition);
        }

    }

    // Start is called before the first frame update

    
    void Start()
    {


        ChangeColor(PlayerPrefs.GetInt("colorPosition"));

        colorPosition= PlayerPrefs.GetInt("colorPosition");
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerPrefs.SetInt("colorPosition", colorPosition);
    }
    //Change the volti color depending in the color introduced
    void ChangeColor(int colorNumber)
    {
        myTrailRenderer.material.SetColor("_TintColor", colorsArray[colorNumber]);

        foreach (GameObject gameObject in imagesColor)
        {
            gameObject.GetComponent<Image>().color = new Color(colorsArray[colorNumber].r, colorsArray[colorNumber].g, colorsArray[colorNumber].b);
        }
        

        var main1 = circlePS.main;
        //main1.startColor = colorsArray[colorNumber];

        main1.startColor = new ParticleSystem.MinMaxGradient(colorsArray[colorNumber]);
        
        var main2 = particlesPS.main;
        main2.startColor = new ParticleSystem.MinMaxGradient(colorsArray[colorNumber]);

        var main3 = electricBeamPS.main;
        main3.startColor = new ParticleSystem.MinMaxGradient(colorsArray[colorNumber]);

        BeamMT.SetColor("_TintColor", colorsArray[colorNumber]);


    }

   
}
