using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class immortal : MonoBehaviour
{
    public static immortal instance;

    [SerializeField]
    CircleCollider2D bird;

    private void Awake()
    {
        _makeInstance();
    }

    void _makeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void updateTriggerBird(bool immortal)
    {
        if(immortal == true)
        {
            bird.isTrigger = true;
        } else
        {
            bird.isTrigger = false;
        }
    }
}
