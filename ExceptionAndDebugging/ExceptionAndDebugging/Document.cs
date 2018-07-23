using System;
using System.Diagnostics;

namespace ExceptionAndDebugging
{
    struct Document
    {
        public int numOfPapers { get; }

        public Document(int numOfPapers)
        {
            if (numOfPapers==0)
            {
                throw new Exception("Your document is empty!");
            }
            this.numOfPapers = numOfPapers;
            Debug.WriteLine("Document has been created!");

        }

        public void Close()
        {
            Console.WriteLine("Document has been closed!");
        }
    }
}
