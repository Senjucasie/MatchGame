using System.Collections.Generic;
using UnityEngine;

namespace Utilites
{
    public class RandomNumber
    {
        private List<int> _numbers = new List<int>();

        public RandomNumber(int counter)
        {
            CreateList(counter);
        }

        private void CreateList(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _numbers.Add(i);
            }
        }

        public int GetRandomNumber()
        {
            int index = 0;
            if (_numbers.Count > 1)
            {
                index = _numbers[Random.Range(0, _numbers.Count)];
                _numbers.Remove(index);
            }
            else
            {
                index = _numbers[0];
            }
            return index;
        }
    }
}

