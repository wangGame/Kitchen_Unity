using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterAnimation : MonoBehaviour
{
    private bool isShow;
    [SerializeField]
    private GameObject sizzlingParticles;
    [SerializeField]
    private GameObject stoveOnVisual;

    public void ShowStoveEffect() {
        this.isShow = true;
        stoveOnVisual.SetActive(true);
        sizzlingParticles.SetActive(true);
    }

    public void HideStoveEffecct() {
        if (this.isShow) {
            stoveOnVisual.SetActive(false);
            sizzlingParticles.SetActive(false);
        }
    }
}