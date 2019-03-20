//using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RouletteSpin : MonoBehaviour
{
    [SerializeField] private AudioPlayer audioPlayer;
    [SerializeField] private UnityEvent onRouletteDaresEnd;
    [SerializeField] private QuestionSetup questionSetup;
    private bool isSpinning;

    private void OnEnable()
    {
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));
    }

    public void LetItGo()
    {
        if (isSpinning) return;

        StartCoroutine(Spin());
    }

    private void Update()
    {
        if (!isSpinning) return;
        currentTime += Time.deltaTime;
    }

    public float maxSpeed = 10f;

    public float accelRate = 0.01f;
    public float deaccelRate = -0.005f;
    public float multiplierMin = 1.0f;
    public float multiplierMax = 5.0f;
    private float currentSpeed;
    private float multiplier;
    private float timeToDecelerate = 4;
    private float currentTime = 0;
    private float currentAccel = 0;

    private bool retry = false;

    private IEnumerator Spin()
    {
        retry = false;
        isSpinning = true;
        audioPlayer.PlayRouletteClip();

        currentSpeed = 0;
        currentTime = 0;
        currentAccel = accelRate;

        multiplier = Random.Range(multiplierMin, multiplierMax);

        //Debug.Log("multiplier " + multiplier);

        while (true)
        {
            transform.localEulerAngles += new Vector3(0, 0, transform.localEulerAngles.x - currentSpeed);

            currentSpeed += currentAccel * multiplier;

            if (currentSpeed >= maxSpeed)
            {
                currentSpeed = maxSpeed;
            }

            //Debug.Log("currentSpeed  " + currentSpeed);
            //Debug.Log(transform.localEulerAngles);
            //Debug.Log(currentTime);
            if (currentTime >= timeToDecelerate)
            {
                currentAccel = deaccelRate;

                if (currentSpeed <= 0)
                {
                    currentSpeed = 0;
                    CalculateResult();
                    break;
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private void CalculateResult()
    {
        GetResult();

        StartCoroutine(GiveSeconds());
    }

    private IEnumerator GiveSeconds()
    {
        yield return new WaitForSeconds(2f);

        isSpinning = false;

        if (retry) yield break;

        if (onRouletteDaresEnd != null)
        {
            onRouletteDaresEnd.Invoke();
        }
    }

    private void GetResult()
    {
        float result = transform.localEulerAngles.z;
        int category = 0;
        Debug.Log("this ended " + result);
        if (result > 327.5f || result <= 32.5f)
        {
            category = 0;//azul
        }
        else if (result > 32.5f && result <= 89)
        {
            category = 1;//verde claro
        }
        else if (result > 89 && result <= 146)
        {
            category = 2;//morao

        }
        else if (result > 146 && result <= 213)
        {
            category = 3;//rojo

        }
        else if (result > 213 && result <= 270.5)
        {
            category = 4;//verde oscuro

        }
        else if (result > 270.5 && result <= 327.5)
        {
            category = 5;//amarillo

        }
        else
        {
            category = 0;
        }

        //  category = 2;
        Debug.Log("category " + category);
        questionSetup.SetQuestion(category);

        if (category == 2)
        {
            retry = true;
        }
    }

}
