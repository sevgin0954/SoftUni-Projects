using System;
using System.Collections.Generic;

namespace P01Database
{
    public class Database
    {
        private int[] data = new int[16];
        int currentIndex = 0;

        public Database()
        {

        }

        public Database(params int[] intialValues)
        {
            Data = intialValues;
        }

        private int[] Data
        {
            get => data;
            set
            {
                if (value.Length > data.Length)
                {
                    throw new InvalidOperationException("Invalid Length");
                }

                Add(value);
            }
        }

        private int CurrentIndex
        {
            get => currentIndex;
            set { currentIndex = value; }
        }

        public void Add(params int[] valuesToAdd)
        {
            for (int a = 0; a < valuesToAdd.Length; a++)
            {
                if (CurrentIndex > Data.Length - 1)
                {
                    throw new InvalidOperationException("Index out of range");
                }

                Data[CurrentIndex++] = valuesToAdd[a];
            }
        }

        public void Remove()
        {
            if (CurrentIndex <= 0)
            {
                throw new InvalidOperationException("No elements left");
            }

            Data[CurrentIndex - 1] = default(int);
            CurrentIndex--;
        }

        public int[] Fetch()
        {
            int[] fetchedResult = new int[CurrentIndex];

            for (int a = 0; a < fetchedResult.Length; a++)
            {
                fetchedResult[a] = Data[a];
            }

            return fetchedResult;
        }

        public void FindById(long id)
        {

        }

        public void FindByUsername(string username)
        {

        }
    }
}
