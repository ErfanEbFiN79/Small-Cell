using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    #region Variables

    public static PlayerController intance;
    private enum StatePlayer
    {
        Move,
        Stay,
    }

    private StatePlayer state = StatePlayer.Move;
    
    [Header("Movement")] 
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speedMove;

    [Header("Fire Setting")] 
    [SerializeField] private GameObject[] bullet;
    [SerializeField] private Transform pointShot;
    [SerializeField] private float timeBtwShot;
    private int _orderShot;
    private float timeBtwShotSet;
    public bool canFight { get; private set; }
    
    #endregion

    #region Unity Methods

    private void Awake()
    {
        if (intance == null && intance != this)
        {
            intance = this;
        }
    }

    private void Update()
    {
        ManageStates();
    }

    #endregion

    #region Manager

    private void ManageStates()
    {
        switch (state)
        {
            case StatePlayer.Move:
                Move();
                if (!canFight)
                {
                    TimeShotManager();
                }
                break;
            
            case StatePlayer.Stay:
                
                break;
        }
    }

    private void TimeShotManager()
    {
        timeBtwShotSet += Time.deltaTime;
        if (timeBtwShotSet >= timeBtwShot)
        {
            canFight = true;
        }
    }
    #endregion

    #region Buttons

    public void Fire()
    {
        if (canFight)
        {
            FireAction();
        }

    }

    #endregion

    #region Actions

    private void Move()
    {
        Vector2 move = new Vector2(joystick.Horizontal, joystick.Vertical);
        transform.Translate(move * speedMove * Time.deltaTime);
    }

    private void FireAction()
    {
        if (_orderShot > bullet.Length-1)
        {
            _orderShot = 0;
        }
        Instantiate(
            bullet[_orderShot],
            pointShot.position,
            quaternion.identity
        );
        _orderShot += 1;
        canFight = false;
        timeBtwShotSet = 0;
    }

    #endregion

    
}