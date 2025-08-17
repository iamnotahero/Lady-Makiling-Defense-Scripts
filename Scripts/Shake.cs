using UnityEngine;

public class Shake : MonoBehaviour
{
    public float duration = 0.5f;
    public float amount = 0.1f;
    private Vector3 originalPosition;
    private float startTime;
    
    //private float timer;
    private bool canShake;
    void Start()
    {
        originalPosition = transform.position;
        startTime = Time.time;
        canShake = false;
    }

    void Update()
    {   

        //Debug.Log(startTime);
        if (Time.time < startTime + duration && canShake)
        {   
            Vector3 shakeOffset = new Vector3(Random.Range(-amount, amount), Random.Range(-amount, amount), 0);
            transform.position = originalPosition + shakeOffset;
        }
        else
        {
            transform.position = originalPosition; // Reset position after shake
        }
    }

    public void StartShake()
    {
        startTime = Time.time;
        canShake = true;
    }
}