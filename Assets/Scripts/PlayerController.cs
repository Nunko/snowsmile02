using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowSmile02
{
    public class PlayerController : MonoBehaviour
    {
        public static float rechargingSpeedOfBattery = 2f;
        public static float maxBattery = 100f; //임시

        public static float currentSpeedOfPlayer;        
        public static float currentSpeedOfBattery;
        
        IPlayerState _normalState, _dangerousState, _overState;
        PlayerStateContext _playerStateContext;

        public static bool onRobot = false;

        void Start()
        {
            _playerStateContext = new PlayerStateContext(this);
            _normalState = this.GetComponent<PlayerNormalState>();
            _dangerousState = this.GetComponent<PlayerDangerousState>();
            _overState = this.GetComponent<PlayerOverState>();  
            NormalPlayer();
            
            gameObject.GetComponent<ClientPlayerState>().SetPlayerControllerInClientPlayerState(this);      
        }

        public void NormalPlayer()
        {
            _playerStateContext.Transition(_normalState);
        }

        public void DangerousPlayer()
        {
            _playerStateContext.Transition(_dangerousState);
        }

        public void OverPlayer()
        {
            _playerStateContext.Transition(_overState);
        }   
    }
}