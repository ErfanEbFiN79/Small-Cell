using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables

    [Header("Speed")] 
    [SerializeField] private float speedMove;

    #endregion

    #region Unity Methdos

    private void Update()
    { 
        Move();   
    }

    #endregion

    #region Actions

    private void Move()
    {
        transform.Translate(speedMove * Time.deltaTime,0,0);
    }

    #endregion
}
