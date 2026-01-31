using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class Mediator_PanelUi : Mediator
{
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();

        if (!Scritable.isStartHidden)
            ShowUi();
        else
            HideUi();
    }

    public override void ShowUi()
    {
        if (HasAnimationsType(TypeAnimation.Fade))
        {
            if (!Scritable.isUnScale)
            {
                Timing.RunCoroutine(FadeIn());
            }
            else
            {
                StartCoroutine(FadeInUnscale());
            }
        }

        if (HasAnimationsType(TypeAnimation.Move))
        {
            if (!Scritable.isUnScale)
            {
                Timing.RunCoroutine(MoveIn());
            }
            else
            {
                StartCoroutine(MoveInUnscale());
            }
        }

        if (HasAnimationsType(TypeAnimation.Scale))
        {
            if (!Scritable.isUnScale)
            {
                Timing.RunCoroutine(ScaleIn());
            }
            else
            {
                StartCoroutine(ScaleInUnscale());
            }
        }

        if (HasAnimationsType(TypeAnimation.Rotation))
        {
            if (!Scritable.isUnScale)
            {
                Timing.RunCoroutine(RotationIn());
            }
            else
            {
                StartCoroutine(RotationInUnscale());
            }
        }
    }

    public override void HideUi()
    {
        if (HasAnimationsType(TypeAnimation.Fade))
        {
            if (!Scritable.isUnScale)
            {
                Timing.RunCoroutine(FadeOut());
            }
            else
            {
                StartCoroutine(FadeOutUnscale());
            }
        }

        if (HasAnimationsType(TypeAnimation.Move))
        {
            if (!Scritable.isUnScale)
            {
                Timing.RunCoroutine(MoveOut());
            }
            else
            {
                StartCoroutine(MoveOutUnscale());
            }
        }

        if (HasAnimationsType(TypeAnimation.Scale))
        {
            if (!Scritable.isUnScale)
            {
                Timing.RunCoroutine(ScaleOut());
            }
            else
            {
                StartCoroutine(ScaleOutUnscale());
            }
        }

        if (HasAnimationsType(TypeAnimation.Rotation))
        {
            if (!Scritable.isUnScale)
            {
                Timing.RunCoroutine(RotationOut());
            }
            else
            {
                StartCoroutine(RotationOutUnscale());
            }
        }
    }
}
