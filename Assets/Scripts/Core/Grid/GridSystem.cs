using Core;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Grid
{
    [RequireComponent(typeof(RectTransform), typeof(GridLayoutGroup))]
    public class GridSystem : MonoBehaviour
    {
        [SerializeField] private CardFactory _cardFactory;
        private RectTransform _rectTransform;
        private GridLayoutGroup _gridLayOut;
        public List<Card> Cards;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _gridLayOut = GetComponent<GridLayoutGroup>();
        }


        public void CreateGrid(int row, int column, float spacing)
        {
            _gridLayOut.spacing = new Vector2(spacing, spacing);
            float totalhorizontalspace = _rectTransform.rect.width - (spacing * (column - 1));
            float totalverticalspace = _rectTransform.rect.height - (spacing * (row - 1));
            _gridLayOut.cellSize = new Vector2(CellWidth(column, totalhorizontalspace), CellHeight(row, totalverticalspace));

        }

        public void CreateCell(CardData data)
        {
            Card cell = _cardFactory.CreateCard();
            cell.SetCardData(data);
            Cards.Add(cell);
            cell.GetComponent<RectTransform>().SetParent(_rectTransform, false);
        }

        public void HideAllCards()
        {
            foreach (Card card in Cards)
            {
                card.SetCard();
            }
        }
        private float CellWidth(int row, float width)
        {
            return width / row;
        }
        private float CellHeight(int column, float height)
        {
            return height / column;
        }

        public List<PersistCard> Save()
        {
            List<PersistCard>  cards= new List<PersistCard>();
            foreach(Card card in Cards)
            {
                if(card.GetCardState() == CardState.Clicked)
                {
                    cards.Add(new PersistCard(card.GetCardType(), CardState.Normal));
                }
                else
                {
                    cards.Add(new PersistCard(card.GetCardType(), card.GetCardState()));
                }
                
            }
            return cards;
        }
    }

   

    
}
