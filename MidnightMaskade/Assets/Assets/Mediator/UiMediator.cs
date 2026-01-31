using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class UiMediator : MonoBehaviour
{
    public static UiMediator Instance;

    #region Mediator
    [Header("Mediator System")]
    [SerializeField] private Mediator[] mediators;
    private int currentIdx = 0;
    private int lastIdx = 0;
    private int lastCurIdx;
    #endregion

    #region Getter
    #region Menus Ui Panels
    public Mediator[] Medators
    {
        get { return mediators; }
    }

    public int CurrentIdx()
    {
        return currentIdx;
    }
    #endregion
    #endregion

    #region Change Ui
    //Go to especific UI
    public void GoToUi(int  idx)
    {
        ChangeUiPanel(idx);
    }

    private void ChangeUiPanel(int idx)
    {
        currentIdx = idx;
        lastCurIdx = lastIdx;

        mediators[lastIdx].HideUi();
        mediators[currentIdx].ShowUi();

        lastIdx = currentIdx;
    }

    //Return to last ui
    public void ReturnToLastUi()
    {
        ReturnUi();
    }

    private void ReturnUi()
    {
        mediators[lastIdx].HideUi();
        mediators[lastCurIdx].ShowUi();

        lastIdx = lastCurIdx;
    }
    #endregion

    private void Awake()
    {
        Instance = this;
    }

}
