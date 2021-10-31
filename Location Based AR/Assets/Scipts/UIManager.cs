using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startChallengePanle;
    [SerializeField] GameObject userNotInRangePanel;
    bool isUIPanelActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayStartChallengePanel(bool show)
    {
        startChallengePanle.SetActive(show);
    }

    public void DisplayUserNotInRnagePanel(bool show)
    {
        userNotInRangePanel.SetActive(show);
    }
}
