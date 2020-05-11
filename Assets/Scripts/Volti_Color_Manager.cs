using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volti_Color_Manager : MonoBehaviour
{
    [SerializeField] GameObject player_Circle;
    [SerializeField] GameObject player_Particles;
    [SerializeField] GameObject player_ElectricBeam;
    [SerializeField] TrailRenderer myTrailRenderer ;

    ParticleSystem circlePS;
    ParticleSystem particlesPS;

    ParticleSystem electricBeamPS;

    [SerializeField] Material BeamMT;
    

    [SerializeField] Color[] colorsArray;

    int saveO;

     int colorPosition;
     int lastColorPosition;

    [SerializeField] Button[] colorsBTNS;

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
        
        //if (saveO == 0 || PlayerPrefs.GetInt("saveO") == 0)
        //{
        //    createInitials();
        //}

       
        



        colorsBTNS[0].onClick.AddListener(() => { colorPosition = 0; PlayerPrefs.SetInt("colorPosition", 0); });
        colorsBTNS[1].onClick.AddListener(() => { colorPosition = 1; PlayerPrefs.SetInt("colorPosition", 1); });
        colorsBTNS[2].onClick.AddListener(() => { colorPosition = 2; PlayerPrefs.SetInt("colorPosition", 2); });
        colorsBTNS[3].onClick.AddListener(() => { colorPosition = 3; PlayerPrefs.SetInt("colorPosition", 3); });
        colorsBTNS[4].onClick.AddListener(() => { colorPosition = 4; PlayerPrefs.SetInt("colorPosition", 4); });
        colorsBTNS[5].onClick.AddListener(() => { colorPosition = 5; PlayerPrefs.SetInt("colorPosition", 5); });
        colorsBTNS[6].onClick.AddListener(() => { colorPosition = 6; PlayerPrefs.SetInt("colorPosition", 6); });
        colorsBTNS[7].onClick.AddListener(() => { colorPosition = 7; PlayerPrefs.SetInt("colorPosition", 7); });
        colorsBTNS[8].onClick.AddListener(() => { colorPosition = 8; PlayerPrefs.SetInt("colorPosition", 8); });
        colorsBTNS[9].onClick.AddListener(() => { colorPosition = 9; PlayerPrefs.SetInt("colorPosition", 9); });

        // myButton.onClick.AddListener( () => {myFunctionForOnClickEvent("stringValue", 4.5f);} );  //

        //ChangeColor(PlayerPrefs.GetInt("colorPosition"));
        //ChangeColor(colorPosition);
        lastColorPosition = colorPosition;
        colorPosition= PlayerPrefs.GetInt("colorPosition");
    }

    // Update is called once per frame
    void Update()
    {
        



        PlayerPrefs.SetInt("colorPosition", colorPosition);
        //Debug.Log(colorPosition);
        //ChangeColor(PlayerPrefs.GetInt("colorPosition"));
        
        if (colorPosition < 0)
        {
            colorPosition = 0;
        }
        if (colorPosition > 9)
        {
            colorPosition = 9;
        }

        if (colorPosition != lastColorPosition)
        {
            ChangeColor(colorPosition);
            //colorPosition = lastColorPosition;
            lastColorPosition = colorPosition;
            PlayerPrefs.SetInt("colorPosition", colorPosition);
            //ChangeColor(PlayerPrefs.GetInt("colorPosition"));
        }

        //ChangeColor(PlayerPrefs.GetInt("colorPosition"));

    }

    void ChangeColor(int colorNumber)
    {
        myTrailRenderer.material.SetColor("_TintColor", colorsArray[colorNumber]);

       var main1 = circlePS.main;
        //main1.startColor = colorsArray[colorNumber];

        main1.startColor = new ParticleSystem.MinMaxGradient(colorsArray[colorNumber]);
        
        var main2 = particlesPS.main;
        main2.startColor = new ParticleSystem.MinMaxGradient(colorsArray[colorNumber]);

        var main3 = electricBeamPS.main;
        main3.startColor = new ParticleSystem.MinMaxGradient(colorsArray[colorNumber]);

        BeamMT.SetColor("_TintColor", colorsArray[colorNumber]);


    }

    void createInitials() 
    {
        PlayerPrefs.SetInt("colorPosition", 0);
        saveO = 1;
        PlayerPrefs.SetInt("saveO", 1);

    }
}
