using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowSmile02
{
    public class PlayerDangerousState : MonoBehaviour, IPlayerState
    {
        PlayerController _playerController;

        public float speedOfPlayer = 2f;
        public float usedSpeedOfBattery = -2f;
        public Sprite playerSprite;

        public void Handle(PlayerController playerController)
        {
            if (!_playerController) _playerController = playerController;
            
            PlayerController.currentSpeedOfPlayer = speedOfPlayer;
            PlayerController.currentSpeedOfBattery = usedSpeedOfBattery;
            this.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().sprite = playerSprite;
        }
    }
}