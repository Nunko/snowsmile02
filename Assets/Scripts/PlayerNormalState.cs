using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowSmile02
{
    public class PlayerNormalState : MonoBehaviour, IPlayerState
    {
        PlayerController _playerController;

        public float speedOfPlayer = 1f;
        public float usedSpeedOfBattery = -1f;
        public Sprite playerSpriteNormal;
        public Sprite playerSpriteRecharging;
        public Sprite playerSpriteHeavy;

        public void Handle(PlayerController playerController)
        {
            if (!_playerController) _playerController = playerController;

            PlayerController.currentSpeedOfPlayer = speedOfPlayer;
            PlayerController.currentSpeedOfBattery = usedSpeedOfBattery;
            this.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().sprite = playerSpriteNormal;
        }
    }
}