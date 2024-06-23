using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


// Скрипт управління камерою
public class CameraScript : MonoBehaviour
{
    private GameObject ball;   // посилання на об'єкт на сцені
    private UnityEngine.Vector3 offset;   // зміщення камери відносно персонажу
    private UnityEngine.Vector3 mAngles;   // кути накопичені рухом миші\
    private float sensitivityH = 2.0f;
    private float sensitivityV = 1.0f;
    
    void Start()
    {
        ball = GameObject.Find("Ball");
        offset = this.transform.position - ball.transform.position;
        mAngles = this.transform.eulerAngles;
    }
    private void Update()
    {
        mAngles.y += Input.GetAxis("Mouse X") * sensitivityH;
        mAngles.x -= Input.GetAxis("Mouse Y") * sensitivityV;

        if (mAngles.x > 70f) mAngles.x = 70f;
        if (mAngles.x < 40f) mAngles.x = 40f;

        if (mAngles.y > 360) mAngles.y -= 360;
        if (mAngles.y < 0) mAngles.y += 360;
 
    }


    void LateUpdate()
    {
        // слідуванння - камера рухається слідом за персонажем
        // ігноруючі його обертання
        this.transform.position = offset + ball.transform.position + 
          UnityEngine.Quaternion.Euler(0, mAngles.y, 0) * offset;
        this.transform.eulerAngles = mAngles;
    }
}
