using System;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    #region Variables

    [Header("Shot Ui")] 
    [SerializeField] private GameObject shotImage;

    #endregion
    
    #region Unity Methods

    private void Update()
    {
        ShotManager();
    }

    #endregion

    #region Manager

    private void ShotManager()
    {
        if (PlayerController.intance.canFight)
        {
            shotImage.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        }
        else
        {
            shotImage.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
    }

    #endregion
}
