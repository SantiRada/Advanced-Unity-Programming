using UnityEngine;
using DG.Tweening;

public class ShipMovement : MonoBehaviour {

    [Header("Selector")]
    public Ease ease;

    private void Start()
    {
        transform.DOMoveX(0, 2).SetEase(ease);
    }
}
