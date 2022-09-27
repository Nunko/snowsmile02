using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowSmile02
{
    public class Player : MonoBehaviour
    {
        public static float battery;        
        
        Vector3 touchPoint;
        bool isMoving = false;

        void Start()
        {
            battery = PlayerController.maxBattery;
        }

        void OnEnable()
        {
            SetStartPosition();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) == true && PlayerController.onRobot == true)
            {
                GetTouchPoint();
                isMoving = true;
                Debug.Log("touchPoint " + touchPoint.ToString());  
                
            }

            if (isMoving == true)
            {                
                MoveToPoint();
                CheckArrival();
            }
        }

        void FixedUpdate()
        {
            if (isMoving == true)
            {
                ChangeBattery();
            }
        }

        void SetStartPosition()
        {
            Vector3 currentPosition = this.transform.position;
            this.transform.position = new Vector3(currentPosition.x, currentPosition.y, 0);
        }   

        void GetTouchPoint()
        {
            Vector3 _touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPoint = new Vector3(_touchPoint.x, _touchPoint.y, 0);
        }

        void CheckArrival()
        {
            if (this.transform.position == touchPoint)
            {
                isMoving = false;
                Debug.Log("touchPoint " + touchPoint.ToString() + "에 도착"); 
            }               
        }

        void MoveToPoint()
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, touchPoint, PlayerController.currentSpeedOfPlayer*Time.deltaTime);                    
        }    

        void ChangeBattery()
        {
            battery += PlayerController.currentSpeedOfBattery*Time.deltaTime;
        }
    }
}