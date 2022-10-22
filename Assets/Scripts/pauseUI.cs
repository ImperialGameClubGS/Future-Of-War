using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class pauseUI : MonoBehaviour
{
    #region FIELDS
    /// <summary>
    /// True if the character press ESC
    /// </summary>

    private bool flagUI=false;

    [SerializeField]
    private GameObject UIpanel;

    public GameObject UIPanelPlayer;

    #endregion

    private void Update()
    {
        //Trial adding ESC via update and PlayerUI
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // UIpanel.SetActive(true);

            if (flagUI)
            {
                UIpanel.SetActive(false);
                UIPanelPlayer.SetActive(true);
                flagUI = false;
            }
            else
            {
                UIpanel.SetActive(true);
                UIPanelPlayer.SetActive(false);
                flagUI = true;
            }
        }
    }

    // Exit button click handler
    public void ExitButton()
    {
        Application.Quit();
    }
}
