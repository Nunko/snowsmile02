using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnowSmile02
{
    public class Title : MonoBehaviour
    {
        void Awake()
        {
            Debug.Log("게임 실행");
            Input.multiTouchEnabled = false;        
        }

        void OnEnable()
        {
            
        }

        void Update()
        {
            
        }

        public void PointerUpTitle()
        {
            Debug.Log("메인 씬으로 진입 시도");
            StartCoroutine(LoadAsyncScene("Main"));
        }

        IEnumerator LoadAsyncScene(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        } 
    }
}