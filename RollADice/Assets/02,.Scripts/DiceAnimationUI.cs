using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class DiceAnimationUI : MonoBehaviour
{
    public static DiceAnimationUI instance;
    [SerializeField] private Image _image;
    [SerializeField] private float _animationDelay;
    [SerializeField] protected float _animationTime;
    private float _timer;
    private List<Sprite> sprites = new List<Sprite>();

    private void Awake()
    {
        instance = this;
        LoadSprites();
    }

    private void LoadSprites()
    {
        sprites = Resources.LoadAll<Sprite>("DiceImages").ToList();        
    }

   

    //private class E_DiceAnimationEnum : IEnumerator
    //{
    //    public int MoveNext()
    //    {
    //        int state = 0;
    //        switch (state)
    //        {
    //            case 0:
    //                if (gameManager.instance != null)
    //                   {
    //                          state++
    //                          return 1;
    //                    }
    //                return 1;
    //            case 1:
    //                return 2;
    //            case 2:
    //                return 3;
    //            default:
    //                return -1;
    //        }
    //    }
    //}

    public void DoDiceAnimation()
    {
        StartCoroutine(E_DiceAnimation());
    }

    IEnumerator E_DiceAnimation()
    {
        float elapsedTime = 0;
        while (elapsedTime < _animationTime)
        {
            if (_timer < 0)
            {
                _image.sprite = sprites[Random.Range(0, sprites.Count)];
                _timer = _animationDelay;
            }
            _timer -= Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

       // while(elapsedTime < _animationTime)
       // {
       //     _image.sprite = sprites[Random.Range(0, sprites.Count)];
       //     yield return new WaitForSeconds(_animationDelay);
       // }               
    }
}
