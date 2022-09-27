using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowSmile02
{
    public class CameraController : MonoBehaviour
    {
        public float speed;

        public GameObject GameUIPanel;
        public GameObject Player;

        void FixedUpdate()
        {
            if (GameUIPanel.activeSelf == true)
            {
                FollowPlayer();
            }
        }

        void FollowPlayer()
        {
            Vector3 playerPosition = Player.transform.position;
            Vector3 _playerPosition = new Vector3(playerPosition.x, playerPosition.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, _playerPosition, speed*Time.deltaTime);
        }
    }
}