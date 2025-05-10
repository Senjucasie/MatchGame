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
    
        private float _rotatedAngle;
        [SerializeField] private float _speed;

        private bool swapped;
       
        private void Awake()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
            swapped = false;
            _button.enabled = false;
        }

        private void Start()
        {
            _button.onClick.AddListener(OnClicked);
        }

        public void SetCardData(CardData data)
        {
            _data = data;
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

       


        public void OnClicked()
        {
            if (_data.State == CardState.Clicked)
            {
                Debug.LogError("The card is not clickable");
            }
            else
            {
                _data.State = CardState.Clicked;
                StartCoroutine(ShowCard());
            }

        }
        
        private IEnumerator ShowCard()
        {
            while (_rotatedAngle < 180)
            {
                _rotatedAngle += _speed * Time.deltaTime;
                transform.Rotate(0, _speed * Time.deltaTime, 0);

                if (_rotatedAngle >= 90 && !swapped)
                {
                    swapped = true;
                    swapImage(_data.Answer);
                }
                yield return null;
            }
            _rotatedAngle = 0;
            swapped = false;

            

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
            _data.State = CardState.Normal;
            _rotatedAngle = 0;

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


