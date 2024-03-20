using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    #region Variables

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
    private int _orderShot;
    
    #endregion

    #region Unity Methods

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
                break;
            
            case StatePlayer.Stay:
                
                break;
        }
    }
    #endregion

    #region Buttons

    public void Fire() => FireAction();

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
    }

    #endregion

    
}