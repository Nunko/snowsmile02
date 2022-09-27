using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SnowSmile02
{
    public class AspectRatio : MonoBehaviour
    {
        public GameObject UICanvas;
        float currentScreenWidth  = Screen.width;
        float currentScreenHeight = Screen.height;

        void Update()
        {
            if (currentScreenWidth != Screen.width || currentScreenHeight != Screen.height)
            {
                currentScreenWidth = Screen.width;
                currentScreenHeight = Screen.height;
                ChangeAspectRatio();
                Debug.Log("화면비 변경됨");
            }
        }

        void ChangeAspectRatio()
        {
            float setAspectRatio = (float) 1/2f;
            float currentAspectRatio = (float) currentScreenWidth/currentScreenHeight;
            if (setAspectRatio >= currentAspectRatio)
            {
                UICanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
            }
            else
            {
                UICanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
            }
        }
    }
}
