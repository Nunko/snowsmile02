using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SnowSmile02
{
    public class MainButton : MonoBehaviour
    {
        public GameObject ParentOfTopButtons;
        public GameObject ParentOfListButtons;
        public GameObject ParentOfGameStage;

        public Color unclickedTopButtonColor;        
        public Color unclearedColor;
        public Color clearedColor;
        public Color clickedColor;

        GameObject _ClickedTopButton;
        GameObject _ClickedListButton;

        public GameObject MainUIPanel;
        public GameObject GameUIPanel;      

        public Object TutorialStage;  

        void Start()
        {
            string previousStep = "small"; //임시
            ChangeColorOfTopButton(previousStep);
        }

        void OnEnable()
        {
            
        }

        void Update()
        {
            
        }

        public void ClickTopButton()
        {
            GameObject CurrentClickedTopButton = EventSystem.current.currentSelectedGameObject;

            if (_ClickedTopButton != CurrentClickedTopButton)
            {
                if (_ClickedTopButton != null) ReturnColorOfTopButton(_ClickedTopButton);
                _ClickedTopButton = CurrentClickedTopButton;
                ChangeColorOfTopButton(CurrentClickedTopButton);
                Debug.Log("버튼 " + CurrentClickedTopButton.name + " 누름");  
            }
        }

        public void ClickListButton()
        {
            GameObject CurrentClickedListButton = EventSystem.current.currentSelectedGameObject; 

            if (_ClickedListButton != CurrentClickedListButton)
            {
                if (_ClickedListButton != null) ReturnColorOfListButton(_ClickedListButton);
                _ClickedListButton = CurrentClickedListButton;
                ChangeColorOfListButton(CurrentClickedListButton);
                Debug.Log("버튼 " + CurrentClickedListButton.name + " 첫 번째 누름");  
            }
            else
            {
                LoadGameStage();
                EnterGameStage();
                Debug.Log("버튼 " + CurrentClickedListButton.name + " 두 번째 누름");  
            }            
        }

        void ChangeColorOfTopButton(string step)
        {
            GameObject PreviousClearedTopButton;

            switch (step)
            {
                case "small" : PreviousClearedTopButton = ParentOfTopButtons.transform.GetChild(0).gameObject;
                                break;
                case "medium" : PreviousClearedTopButton = ParentOfTopButtons.transform.GetChild(1).gameObject;
                                break;
                case "large" : PreviousClearedTopButton = ParentOfTopButtons.transform.GetChild(2).gameObject;
                                break;
                default : PreviousClearedTopButton = ParentOfTopButtons.transform.GetChild(0).gameObject;
                            break;
            }

            _ClickedTopButton = PreviousClearedTopButton;

            GameObject Indicater = PreviousClearedTopButton.transform.Find("TopColor").gameObject;
            Indicater.GetComponent<Image>().color = clickedColor;
        }

        void ChangeColorOfTopButton(GameObject InputGameObject)
        {
            GameObject Indicater = InputGameObject.transform.Find("TopColor").gameObject;
            Indicater.GetComponent<Image>().color = clickedColor;
        }

        void ReturnColorOfTopButton(GameObject InputGameObject)
        {
            GameObject Indicater = InputGameObject.transform.Find("TopColor").gameObject;
            Indicater.GetComponent<Image>().color = unclickedTopButtonColor;
        }

        void ChangeColorOfListButton(GameObject InputGameObject)
        {
            GameObject Indicater = InputGameObject.transform.Find("Image96").gameObject;
            Indicater.GetComponent<Image>().color = clickedColor;
        }

        void ReturnColorOfListButton(GameObject InputGameObject)
        {
            GameObject Indicater = InputGameObject.transform.Find("Image96").gameObject;
            Indicater.GetComponent<Image>().color = (isCleared() == true) ? clearedColor : unclearedColor;
        }

        bool isCleared() //임시
        {
            return false;
        }

        void EnterGameStage()
        {
            Invoke ("CloseMainPanel", 0.3f);      
            Invoke ("OpenGamePanel", 0.6f);    
        }

        void CloseMainPanel()
        {
            MainUIPanel.SetActive(false);
            Debug.Log("MainPanel 닫음"); 
        }

        void OpenGamePanel()
        {
            GameUIPanel.SetActive(true);
            Debug.Log("GamePanel 엶"); 
        }        

        void LoadGameStage()
        {
            GameObject NewStage = Instantiate(TutorialStage, ParentOfGameStage.transform) as GameObject;
            NewStage.transform.localScale = new Vector3(100, 100, 1);

            GameObject Player = GameObject.FindWithTag("Player");
            GameObject PlayerPoint =  GameObject.Find("PlayerPoint");
            Player.transform.position = new Vector3(PlayerPoint.transform.position.x, PlayerPoint.transform.position.y, Player.transform.position.z);

            GameObject Enemy = GameObject.FindWithTag("Enemy");
            GameObject EnemyPoint =  GameObject.Find("EnemyPoint0");
            Enemy.transform.position = new Vector3(EnemyPoint.transform.position.x, EnemyPoint.transform.position.y, Enemy.transform.position.z);
        }
    }
}
