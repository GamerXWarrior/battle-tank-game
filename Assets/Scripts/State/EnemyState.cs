﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Enemy;

[RequireComponent(typeof(EnemyView))]
public class EnemyState : MonoBehaviour
{
    protected EnemyView enemyView;
    [SerializeField]
    protected Color changedColor;

    private void Awake()
    {
        enemyView = GetComponent<EnemyView>();
    }
    public virtual void OnEnterState()
    {
        this.enabled = true;
    }
    public virtual void OnExitState()
    {
        this.enabled = false;
    }

    //public virtual void Tick() //Update
    //{

    //}
}
 