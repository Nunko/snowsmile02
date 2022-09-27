using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowSmile02
{
    public class PlayerOverState : MonoBehaviour, IPlayerState
    {
        PlayerController _playerController;

        public float speedOfPlayer = 0f;
        public float usedSpeedOfBattery = -100f;
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