using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowSmile02
{
    public class ClientPlayerState : MonoBehaviour
    {
        PlayerController _playerController;

        public static List<int> FactorsOfState = new List<int>() {0};
        int maxNumber;

        void OnEnable()
        {
            maxNumber = FactorsOfState.Max();
        }

        void Update()
        {
            if (_playerController)
            {
                int currentMaxNumber = FactorsOfState.Max();

                if (maxNumber != currentMaxNumber)
                {
                    switch (currentMaxNumber)
                    {
                        case 0 : _playerController.NormalPlayer();
                                break;
                        case 1 : _playerController.DangerousPlayer();
                                break;
                        case 2 : _playerController.OverPlayer();
                                break;
                        default: _playerController.NormalPlayer();
                                break;
                    }

                    maxNumber = currentMaxNumber;
                }
            }            
        }

        public void SetPlayerControllerInClientPlayerState(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public static void AddFactorsOfState(int number)
        {
            if (FactorsOfState.Contains(number) == false)
            {
                FactorsOfState.Add(number);
            }
        }

        public static void RemoveFactorsOfState(int number)
        {
            if (FactorsOfState.Contains(number) == true)
            {
                FactorsOfState.Remove(number);
            }
        } 
    }
}