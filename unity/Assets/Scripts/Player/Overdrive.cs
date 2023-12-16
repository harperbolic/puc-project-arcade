using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overdrive : MonoBehaviour
{
    public bool canOverdrive;
    private bool isOverdrive, back;
    private Vector3 initialPosition, targetPosition;
    private float timeCount = 0.0f;
    private Player mainScript;
    [SerializeField] private float overdriveTime = 0.2f;
    [SerializeField] private float overdrivePower = 0.6f;
    [SerializeField] private float returnTime = 0.4f;

    void Start()
    {
        canOverdrive = true;
        isOverdrive = false;
        mainScript = GetComponent<Player>();
    }
    void Update()
    {
        if (canOverdrive && Input.GetButtonDown("Overdrive"))
        {
            initialPosition = transform.position;
            isOverdrive = true;
            canOverdrive = false;
            mainScript.ChangeInvincibility();
        }
        if (isOverdrive)
        {
            targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + overdrivePower);
            transform.position = Vector3.Lerp(transform.position, targetPosition, timeCount);
            timeCount += Time.deltaTime / overdriveTime;

            if (timeCount >= 1.0f)
            {
                transform.position = targetPosition;
                isOverdrive = false;
                back = true;
                timeCount = 0.0f;
            }
        }
        if (back)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, timeCount);
            timeCount += Time.deltaTime / returnTime;
            if (timeCount >= 1.0f)
            {
                transform.position = initialPosition;
                back = false;
                timeCount = 0.0f;
                mainScript.ChangeInvincibility();
            }
        }

    }
}