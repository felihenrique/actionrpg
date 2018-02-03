using System;
using System.Collections;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public string effectName;
    public Sprite icon;
    public string description;
    public float duration;
    public float tickInterval;
    public bool infinite;

    private float timeCounter;

    protected virtual void OnInit(GameObject obj) {}
    protected virtual void OnTick() {}
    protected virtual void OnEnd() {}

    public void Stop () {
        OnEnd();
        Destroy(gameObject);
    }

    void Start()
    {
        OnInit(transform.parent.gameObject);
    }

    void Update() 
    {
        if (!infinite)
        {
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                OnTick();
                Stop();
            }
        }

        timeCounter += Time.deltaTime;
        if (timeCounter >= tickInterval)
        {
            timeCounter = 0;
            OnTick();
        }
    }
}    
