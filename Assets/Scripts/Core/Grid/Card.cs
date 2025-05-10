using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image),typeof(Button))]
public class Card : MonoBehaviour
{
   
    private Image _image;
    private Button _button;
    [SerializeField] private Sprite _hide;
    [SerializeField] private Sprite _answer;
     private float _rotatedAngle;
    [SerializeField]private float _speed;

    private bool swapped;
    public enum CardState
    {
        Normal,
        Clicked,
        Won
    }

    public CardState State { get; private set; }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        swapped = false;
    }

    private void Start()
    {
        _button.onClick.AddListener(OnClicked);
    }
    public void SetCardState(CardState state)
    {
       State = state;
    }
    public void OnClicked()
    {
        if (State == CardState.Clicked)
        {
            Debug.LogError("The card is not clickable");
        }
        else
        {
            State = CardState.Clicked;
            StartCoroutine(ShowCard());
        }

    }
    private IEnumerator ShowCard()
    {
        while (_rotatedAngle < 180)
        {
            _rotatedAngle += _speed * Time.deltaTime;
            transform.Rotate(0, _speed * Time.deltaTime, 0);

            if(_rotatedAngle >= 90 && !swapped)
            {
                swapped = true;
                swapImage(_answer);
            }
            yield return null;
        }
        _rotatedAngle = 0;
        swapped = false;

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(HideCard());
      
    }

    private IEnumerator HideCard()
    {
       
        while (_rotatedAngle < 180)
        {
            _rotatedAngle += _speed * Time.deltaTime;
            transform.Rotate(0, -_speed * Time.deltaTime, 0);
            if (_rotatedAngle >= 90 && !swapped)
            {
                swapped = true;
                swapImage(_hide);
            }
            yield return null;
        }
        swapped = false;
        State = CardState.Normal;
        _rotatedAngle = 0;

    }
    
    
    private void swapImage(Sprite sprite)
    {
        _image.sprite = sprite;
    }

}
