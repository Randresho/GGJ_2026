using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using MEC;
using Unity.VisualScripting;

[Flags] public enum TypeAnimation { None = 0, Fade = 1, Move = 2, Scale = 4, Rotation = 8, }
[RequireComponent(typeof(CanvasGroup))]
public abstract class Mediator : MonoBehaviour
{
    #region Variables
    #region Hide in inspector
    [HideInInspector] public CanvasGroup canvasGroup;
    [HideInInspector] public RectTransform rectTransform;
    [HideInInspector] public Vector3 startPosUi;
    #endregion

    #region Menu Information   
    [Header("Menu information")]
    [SerializeField] private Mediator_Scritable _Scritable;

    [Header("Objects")]
    [SerializeField] private List<GameObject> items = new List<GameObject>();
    #endregion
    #endregion

    #region Getters
    #region Menu Information
    public Mediator_Scritable Scritable
    {
        get { return _Scritable; }
    }
    #endregion
    #endregion

    public bool HasAnimationsType(TypeAnimation typeAnimations)
    {
       // return AnimationType == TypeAnimation.Fade ? false : (typeAnimation & typeAnimations) != 0;
       return (_Scritable.typeAnimation & typeAnimations) != 0;
    }

    public abstract void ShowUi();

    public abstract void HideUi();

    #region Animations
    #region Fade
    //Animation In
    public IEnumerator<float> FadeIn()
    {
        yield return Timing.WaitForSeconds(_Scritable.waitTime);

        canvasGroup.DOFade(1f, _Scritable.animationTime);

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }    

    //Animation Out
    public IEnumerator<float> FadeOut()
    {
        yield return Timing.WaitForSeconds(_Scritable.waitTime);

        canvasGroup.DOFade(0f, _Scritable.animationTime);

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    #endregion

    #region Move
    //Animation In
    public IEnumerator<float> MoveIn()
    {
        foreach (GameObject item in items)
        {
            rectTransform.transform.localPosition = startPosUi;
            rectTransform.DOAnchorPos(_Scritable.posUiIn, _Scritable.animationTime, false).SetEase(Ease.OutElastic);
            yield return Timing.WaitForSeconds(_Scritable.waitTime);
        }

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    //Animation Out
    public IEnumerator<float> MoveOut()
    {
        foreach (GameObject item in items)
        {
            rectTransform.transform.localPosition = startPosUi;
            rectTransform.DOAnchorPos(_Scritable.posUiOut, _Scritable.animationTime, false).SetEase(Ease.OutElastic);
            yield return Timing.WaitForSeconds(_Scritable.waitTime);
        }

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    #endregion

    #region Scale
    // Animation In
    public IEnumerator<float> ScaleIn()
    {
        foreach (GameObject item in items)
        {
            item.transform.localScale = Vector3.zero;
            item.transform.DOScale(1f, _Scritable.animationTime).SetEase(Ease.OutBounce);
            yield return Timing.WaitForSeconds(_Scritable.waitTime);
        }

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    // Animation Out
    public IEnumerator<float> ScaleOut()
    {
        foreach (GameObject item in items)
        {
            item.transform.localScale = Vector3.zero;
            item.transform.DOScale(0f, _Scritable.animationTime).SetEase(Ease.OutBounce);
            yield return Timing.WaitForSeconds(_Scritable.waitTime);
        }

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    #endregion

    #region Rotation
    //Rotation In
    public IEnumerator<float> RotationIn()
    {
        foreach(GameObject item in items)
        {
            item.transform.localRotation = Quaternion.identity;
            item.transform.DORotate(new Vector3(_Scritable.rotationUiIn.x, 0f, _Scritable.rotationUiIn.y), _Scritable.animationTime).SetEase(Ease.OutBounce);
            yield return Timing.WaitForSeconds(_Scritable.waitTime);
        }

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    //Rotation Out
    public IEnumerator<float> RotationOut()
    {
        foreach (GameObject item in items)
        {
            item.transform.localRotation = Quaternion.identity;
            item.transform.DORotate(new Vector3(_Scritable.rotationUiOut.x, 0f, _Scritable.rotationUiOut.y), _Scritable.animationTime).SetEase(Ease.OutBounce);
            yield return Timing.WaitForSeconds(_Scritable.waitTime);
        }

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    #endregion
    #endregion

    #region Animations Unscale
    #region Fade
    public IEnumerator FadeInUnscale()
    {
        yield return new WaitForSecondsRealtime(_Scritable.waitTime);

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public IEnumerator FadeOutUnscale()
    {
        yield return new WaitForSecondsRealtime(_Scritable.waitTime);

        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    #endregion

    #region Move
    public IEnumerator MoveInUnscale()
    {
        yield return new WaitForSecondsRealtime(_Scritable.waitTime);

        foreach(GameObject item in items)
        {
            rectTransform.transform.localPosition = startPosUi;
            rectTransform.transform.localPosition = _Scritable.posUiIn;
        }

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public IEnumerator MoveOutUnscale()
    {
        yield return new WaitForSecondsRealtime(_Scritable.waitTime);

        foreach (GameObject item in items)
        {
            rectTransform.transform.localPosition = startPosUi;
            rectTransform.transform.localPosition = _Scritable.posUiOut;
        }

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    #endregion

    #region Scale
    public IEnumerator ScaleInUnscale()
    {
        yield return new WaitForSecondsRealtime(_Scritable.waitTime);

        foreach (GameObject item in items)
        {
            item.transform.localScale = Vector3.zero;
            item.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public IEnumerator ScaleOutUnscale()
    {
        yield return new WaitForSecondsRealtime(_Scritable.waitTime);

        foreach (GameObject item in items)
        {
            item.transform.localScale = Vector3.zero;
            item.transform.localScale = new Vector3(0f, 0f, 0f);
        }

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    #endregion

    #region Rotation
    public IEnumerator RotationInUnscale()
    {
        yield return new WaitForSecondsRealtime(_Scritable.waitTime);

        foreach (GameObject item in items)
        {
            item.transform.localRotation = Quaternion.identity;
            item.transform.localRotation = Quaternion.Euler(new Vector3(_Scritable.rotationUiIn.x, 0f, _Scritable.rotationUiIn.y));
        }

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public IEnumerator RotationOutUnscale()
    {
        yield return new WaitForSecondsRealtime(_Scritable.waitTime);

        foreach (GameObject item in items)
        {
            item.transform.localRotation = Quaternion.identity;
            item.transform.localRotation = Quaternion.Euler(new Vector3(_Scritable.rotationUiOut.x, 0f, _Scritable.rotationUiOut.y));
        }

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    #endregion
    #endregion
}
