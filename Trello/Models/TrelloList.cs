using System;
using System.Collections.Generic;
using System.Text;
using Trello.Services;

namespace Trello.Models
{
    public class TrelloList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentBoardId { get; set; }
        public List<TrelloCard> Cards { get; set; }

        public TrelloList()
        {
            Id = RandomNumberService.Instance.GenerateRandomNumber().ToString();
            Cards = new List<TrelloCard>();
        }

        public void Print()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Cards: ");
            foreach(var card in Cards)
            {
                card.Print();
            }
        }
    }
}
