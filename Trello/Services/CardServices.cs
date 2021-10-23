using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trello.Models;

namespace Trello.Services
{
    class CardServices
    {
        private static CardServices _instance;
        private List<TrelloCard> _cards;

        private CardServices()
        {
            _cards = new List<TrelloCard>();
        }

        public static CardServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CardServices();
                }
                return _instance;
            }
        }

        public void Add(TrelloCard trelloCard)
        {
            _cards.Add(trelloCard);
            ListServices.Instance.AddCardToList(trelloCard);
        }

        internal void Remove(string id)
        {
            TrelloCard card = (from trelloCard in _cards where trelloCard.Id == id select trelloCard).First();
            ListServices.Instance.RemoveCardFromList(card);
            _cards.Remove(card);
        }

        internal void Show(string id)
        {
            TrelloCard card = (from trelloCard in _cards where trelloCard.Id == id select trelloCard).First();
            card.Print();
        }

        internal void ShowAll()
        {
            foreach (var card in _cards)
            {
                card.Print();
            }
        }

        internal void RemoveCardsOfParticularList(string listId)
        {
            List<TrelloCard> cards = (from trelloCard in _cards where trelloCard.ParentListId == listId select trelloCard).ToList();
            _cards.RemoveAll(card => cards.Contains(card));
        }
    }
}
