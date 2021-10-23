using System;
using System.Collections.Generic;
using System.Text;
using Trello.Services;

namespace Trello.Models
{
    public class TrelloBoard
    {
        public BoardPrivacy Privacy { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<string> Members { get; set; }
        public List<TrelloList> Lists { get; set; }
        public string Id { get; set; }
        public TrelloBoard()
        {
            Id = RandomNumberService.Instance.GenerateRandomNumber().ToString();
            Privacy = BoardPrivacy.Public;
            Lists = new List<TrelloList>();
            Members = new List<string>();
        }

        public void Print()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Url: " + Url);
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Members: " + String.Join(',', Members));
            Console.WriteLine("Privacy: " + Privacy);
            Console.WriteLine("Lists: ");
            foreach(var list in Lists)
            {
                list.Print();
            }
        }
    }

    public enum BoardPrivacy
    {
        Public,
        Private
    }
}
