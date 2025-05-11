using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    [RequireComponent(typeof(Image), typeof(Button))]
    public class Card : MonoBehaviour
    {
        
        private Image _image;
        private Button _button;
        [SerializeField]private CardData _data;
        [SerializeField] private Sprite _hide;
       
        private void Awake()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
            _button.enabled = false;
        }

        
        private void Start()
        {
            _button.onClick.AddListener(OnClicked);
            
        }

        public void SetCardData(CardData data)
        {
            _data = data;
            if(data.State == CardState.Won)
            {
                _image.enabled = false;
            }
                
            _image.sprite = _data.Answer;

        }
        public void SetCard()
        {
           if(_data.State== CardState.Normal)
            {
                _image.sprite = _hide;
                _button.enabled = true;
            }
        }

       public int GetCardType()
        {
            return _data.CardType;  
        }
        public CardState GetCardState()
        {
            return _data.State;
        }

        public void OnClicked()
        {
            if (_data.State == CardState.Clicked)
            {
                Debug.LogError("The card is not clickable");
            }
            else
            {
                _data.State = CardState.Clicked;
                ShowCard();
            }

        }
        
        

        public void ShowCard()
        {
      
            swapImage(_data.Answer);
            Invoke("delayToShow",0.5f);

        }

        private void delayToShow()
        {
            EventManager.InvokeCardVisibleEvent(this);
        }
        
        public void HideCard()
        {
         
            swapImage(_hide);
      
            _data.State = CardState.Normal;

        }

        public void Won()
        {
            _image.enabled = false;
            _data.State = CardState.Won;
        }

        private void swapImage(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        
    }
    public enum CardState
    {
        Normal,
        Clicked,
        Won
    }
}


