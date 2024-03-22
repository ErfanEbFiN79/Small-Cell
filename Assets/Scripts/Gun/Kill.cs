using System;
using UnityEngine;
public class Kill : MonoBehaviour
{
    #region Variables

    [Header("Setting")] 
    [SerializeField] private string[] tagsWork;
    
    #endregion

    #region Check

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (string str in tagsWork)
        {
            if (other.CompareTag(str))
            {
                Destroy(other.gameObject);
            }
        }
    }
    
    #endregion
}
