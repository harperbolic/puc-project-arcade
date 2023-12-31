using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class StageTransition : MonoBehaviour
{
    public float transitionTime = 3.0f; // Tempo para a transição completa
    private bool inTransition;
    private bool inReverseTransition;
    private float timeCount;
    private Color color = new Color(15,10, 19,1);
    public Material skyboxMaterial2;
    void Update()
    {
        
        if (inTransition)
        {
            Camera.main.fieldOfView = Mathf.Lerp(60, 30, timeCount);
            Camera.main.transform.rotation = Quaternion.Lerp(Quaternion.Euler(30, 0, 0), Quaternion.Euler(50, 0, 0), timeCount);
            timeCount += Time.deltaTime*2 / transitionTime;



            if (timeCount >= 1.0f)
            {
                inTransition = false;
                RenderSettings.skybox = skyboxMaterial2;
                RenderSettings.fogColor = color;
                inReverseTransition = true;
                timeCount = 0.0f;
            }
        }
        if (inReverseTransition)
        {
            Camera.main.fieldOfView = Mathf.Lerp(30, 60, timeCount);
            Camera.main.transform.rotation = Quaternion.Lerp(Quaternion.Euler(50, 0, 0), Quaternion.Euler(30, 0, 0), timeCount);
            timeCount += Time.deltaTime*2 / transitionTime;


            if (timeCount >= 1.0f)
            {
                inTransition = false;
                inReverseTransition = false;
                timeCount = 0.0f;
            }
        }
    }

    public void StartTransition()
    {
        inTransition = true;
    }
}
