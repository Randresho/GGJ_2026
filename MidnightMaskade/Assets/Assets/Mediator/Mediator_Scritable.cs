using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mediator_Panel", menuName = "Mediator/Panel")]
public class Mediator_Scritable : ScriptableObject
{
    #region Variables
    #region Menu Information
    [Header("Menu information")]
    public TypeAnimation typeAnimation = TypeAnimation.None;
    public bool isStartHidden = false;
    public bool isUnScale;
    [Header("Pos")]
    public Vector2 posUiIn;
    public Vector2 posUiOut;
    [Header("Rotation")]
    public Vector2 rotationUiIn;
    public Vector2 rotationUiOut;
    #endregion

    #region Animations
    [Header("Animations")]
    public float animationTime = 0.5f;
    public float waitTime = 0.05f;
    #endregion
    #endregion
}
