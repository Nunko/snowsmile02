using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SnowSmile02
{
    public class GameButton : MonoBehaviour
    {
        public float _battery;
        public Color greenColorOfBatteryBar;
        public Color yellowColorOfBatteryBar;
        public Color redColorOfBatteryBar;

        public GameObject MainUIPanel;
        public GameObject GameUIPanel;          
        public GameObject BatteryBar;
        
        void OnEnable()
        {
            GameEventBus.Subscribe(GameEventType.START, TurnOnRobot);
            GameEventBus.Subscribe(GameEventType.QUIT, TurnOffRobot);
        }

        void OnDisable()
        {
            GameEventBus.Unsubscribe(GameEventType.START, TurnOnRobot);
            GameEventBus.Unsubscribe(GameEventType.QUIT, TurnOffRobot);
        }

        void Start()
        {
            GameEventBus.Publish(GameEventType.START); //임시
        }

        void Update()
        {
            ChangeBattery(); //임시
            ChangeWidthOfBatteryBar(); //임시
            ChangeColorOfBatteryBar(); //임시
        }

        public void ClickBackButton()
        {
            GameEventBus.Publish(GameEventType.QUIT); //임시
            Invoke ("CloseGamePanel", 0.3f);      
            Invoke ("OpenMainPanel", 0.6f);    
        }

        void CloseGamePanel()
        {
            GameUIPanel.SetActive(false);
            Debug.Log("GamePanel 닫음"); 
        }

        void OpenMainPanel()
        {
            MainUIPanel.SetActive(true);
            Debug.Log("MainPanel 엶"); 
        }

        void ChangeBattery()
        {
            _battery = Player.battery; //임시
        }

        void ChangeWidthOfBatteryBar()
        {
            float widthOfBatteryBar;
            float heightOfBatteryBar = BatteryBar.GetComponent<RectTransform>().sizeDelta.y;  
            int _filledBatterySlots = filledBatterySlots();

            switch (_filledBatterySlots)
            {
                case 10: widthOfBatteryBar = 136f; break;
                case 9: widthOfBatteryBar = 120f; break;
                case 8: widthOfBatteryBar = 108f; break;
                case 7: widthOfBatteryBar = 96f; break;
                case 6: widthOfBatteryBar = 84f; break;
                case 5: widthOfBatteryBar = 72f; break;
                case 4: widthOfBatteryBar = 60f; break;
                case 3: widthOfBatteryBar = 48f; break;
                case 2: widthOfBatteryBar = 36f; break;
                case 1: widthOfBatteryBar = 24f; break;
                case 0: widthOfBatteryBar = 0f; break;
                default: widthOfBatteryBar = 136f; break;
            }

            BatteryBar.GetComponent<RectTransform>().sizeDelta = new Vector2(widthOfBatteryBar, heightOfBatteryBar);
        }

        void ChangeColorOfBatteryBar()
        {
            int _filledBatterySlots = filledBatterySlots();
            Color _filledColorOfBatteryBar;

            if (_filledBatterySlots <=10 && _filledBatterySlots >=8) _filledColorOfBatteryBar = greenColorOfBatteryBar;
            else if (_filledBatterySlots <=7 && _filledBatterySlots >=3) _filledColorOfBatteryBar = yellowColorOfBatteryBar;
            else if (_filledBatterySlots <=2 && _filledBatterySlots >=0) _filledColorOfBatteryBar = redColorOfBatteryBar;
            else _filledColorOfBatteryBar = greenColorOfBatteryBar;

            BatteryBar.GetComponent<Image>().color = _filledColorOfBatteryBar;
        }

        int filledBatterySlots()
        {                      
            if (_battery <=100 && _battery >90) return 10;
            else if (_battery <=90 && _battery >80) return 9;
            else if (_battery <=80 && _battery >70) return 8;
            else if (_battery <=70 && _battery >60) return 7;
            else if (_battery <=60 && _battery >50) return 6;
            else if (_battery <=50 && _battery >40) return 5;
            else if (_battery <=40 && _battery >30) return 4;
            else if (_battery <=30 && _battery >20) return 3;
            else if (_battery <=20 && _battery >10) return 2;            
            else if (_battery <=10 && _battery >0) return 1;            
            else if (_battery <= 0) return 0;            
            else return 10;            
        }

        void TurnOnRobot()
        {
            PlayerController.onRobot = true;
        }

        void TurnOffRobot()
        {
            PlayerController.onRobot = false;
        }
    }
}