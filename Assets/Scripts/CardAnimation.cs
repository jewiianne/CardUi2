using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardAnimation : MonoBehaviour
{
    private Vector3 defaultScale;

    public GameObject frontImage;
    public GameObject backImage;

    public Camera mainCamera;

    void Start()
    {
        defaultScale = this.transform.localScale;

        backImage.gameObject.SetActive(true);
        frontImage.gameObject.SetActive(false);
    }

    void OnMouseOver()
    {
        Sequence cardSequence = DOTween.Sequence();

        cardSequence.Append(transform.DOScale(Vector3.one * 1.5f, 0.05f).SetEase(Ease.InOutCirc));
    }

    void OnMouseExit()
    {
        Sequence cardSequence = DOTween.Sequence();
 
        cardSequence.Append(transform.DOScale(defaultScale, 0.05f));
    }

    void OnMouseDown()
    {
        Sequence cardSequence = DOTween.Sequence();

        cardSequence.Append(mainCamera.transform.DOShakeRotation(0.5f, 1f, 10, 1f));

        cardSequence.Join(backImage.transform.DORotate(new Vector3(0, 180, 0), 1f).SetEase(Ease.InBack));
        cardSequence.Join(frontImage.transform.DORotate(new Vector3(0, 180, 0), 1f).SetEase(Ease.InBack));

        Invoke("SwapCard", 1f);

    }

    void SwapCard()
    {
        backImage.gameObject.SetActive(false);
        frontImage.gameObject.SetActive(true);  
    }

    

   
    
    
}
