using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowSmile02
{
    public class Enemy : MonoBehaviour
    {
        GameObject Player;
        List<Vector3> playerPosition = new List<Vector3>();      

        public bool isSensing = false;
        public bool isRunning = false;

        void OnEnable()
        {
            SetStartPosition();
            Player = GameObject.Find("Player");
            GameEventBus.Subscribe(GameEventType.SENSING, LookAround);
            GameEventBus.Subscribe(GameEventType.DANGEROUS, RunToPlayer);
        }        

        void OnDisable()
        {
            GameEventBus.Unsubscribe(GameEventType.SENSING, LookAround);
            GameEventBus.Unsubscribe(GameEventType.DANGEROUS, RunToPlayer);
        }

        void LateUpdate()
        {
            CheckSensing();
            
            if (isSensing == true && isRunning == false)
            {
                GameEventBus.Publish(GameEventType.SENSING);                
            }
            else if (isSensing == true && isRunning == true)
            {
                GameEventBus.Publish(GameEventType.DANGEROUS);   
            }
        }

        void SetStartPosition()
        {
            Vector3 currentPosition = this.transform.position;
            this.transform.position = new Vector3(currentPosition.x, currentPosition.y, 0);
        }

        void CheckSensing()
        {            
            if (isSensing == true && playerPosition.Count == 0)
            {
                playerPosition.Add(Player.transform.position);
                Debug.Log("SensingPoint " + playerPosition[0].ToString()); 
            }
            else if (isSensing == false)
            {
                playerPosition.Clear();
            }            
        }

        void LookAround()
        {
            float speed = 1f;
            this.transform.position = Vector3.MoveTowards(this.transform.position, playerPosition[0], speed*Time.deltaTime);  

            if (this.transform.position == playerPosition[0])
            {
                Debug.Log("SensingPoint " + playerPosition[0].ToString() + " 도착"); 
                playerPosition.Clear();
            }
        }

        void RunToPlayer()
        {
            float speed = 1.25f;
            this.transform.position = Vector3.MoveTowards(this.transform.position, Player.transform.position, speed*Time.deltaTime);  
        }
    }
}