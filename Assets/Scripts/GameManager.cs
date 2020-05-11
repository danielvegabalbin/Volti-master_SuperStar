using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;
    public GameObject Volti;
    //[SerializeField] public ProgressBar bar;
    public Slider bar;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;

        SceneManager.LoadSceneAsync((int)SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive);
        
    }

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();


    // Update is called once per frame\
    private void Start()
    {

        LoadGame();
    }
    void Update()
    {
    }

    public void LoadGame() 
    {
        loadingScreen.gameObject.SetActive(true);

        //scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.TITLE_SCREEN));
        //scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive));
        

        StartCoroutine(GetSceneLoadProgress());
    }

    float totalSceneProgress;
    public IEnumerator GetSceneLoadProgress() 
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0;

                foreach (AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress = operation.progress;
                }

                totalSceneProgress = (totalSceneProgress / scenesLoading.Count)*100f;
                bar.value = Mathf.RoundToInt(totalSceneProgress);
                

                yield return null;
            }
        }
        loadingScreen.gameObject.SetActive(false);
    }
}
