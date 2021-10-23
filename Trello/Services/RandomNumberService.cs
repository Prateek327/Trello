using System;
using System.Collections.Generic;
using System.Text;

namespace Trello.Services
{
    public sealed class RandomNumberService
    {
        private RandomNumberService() {
            _randomGen = new Random();
        }
        private static RandomNumberService _instance = null;
        private Random _randomGen;

        public static RandomNumberService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RandomNumberService();
                }
                return _instance;
            }
        }

        public int GenerateRandomNumber()
        {
            return _randomGen.Next(int.MaxValue);
        }
    }
}
