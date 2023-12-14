using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class StageTransition : MonoBehaviour
{
    public float transitionTime = 3.0f; // Tempo para a transição completa
    private bool inTransition = false;
    private bool inReverseTransition = false;
    private float timeCount = 0.0f;
    public Material skyboxMaterial2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T)) //////////// ESSA PARTE DO CÓDIGO É SOMENTE PARA FINS DE TESTE DA FEATURE
        {                                //////////// DELETAR QUANDO ESTIVER INTEGRADO COM LEVEL MANAGER
            inTransition = true;
        }


        if (inTransition)
        {
            Camera.main.fieldOfView = Mathf.Lerp(60, 30, timeCount);
            Camera.main.transform.rotation = Quaternion.Lerp(Quaternion.Euler(30, 0, 0), Quaternion.Euler(50, 0, 0), timeCount);
            timeCount += Time.deltaTime / transitionTime;



            if (timeCount >= 1.0f)
            {
                inTransition = false;
                RenderSettings.skybox = skyboxMaterial2;
                inReverseTransition = true;
                timeCount = 0.0f;
            }
        }
        if (inReverseTransition)
        {
            Camera.main.fieldOfView = Mathf.Lerp(30, 60, timeCount);
            Camera.main.transform.rotation = Quaternion.Lerp(Quaternion.Euler(50, 0, 0), Quaternion.Euler(30, 0, 0), timeCount);
            timeCount += Time.deltaTime / transitionTime;


            if (timeCount >= 1.0f)
            {
                inTransition = false;
                inReverseTransition = false;
                timeCount = 0.0f;
            }
        }
    }

    void StartTransition()
    {
        inTransition = true;
    }
}
