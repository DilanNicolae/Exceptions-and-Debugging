using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionAndDebugging
{
    class Printer
    {
        int papers, inkLevel;

        public Printer(int papers,int inkLevel)
        {
            this.papers = papers;
            this.inkLevel = inkLevel;
        }

        public void Print(Document document,int numOfCopies)
        {
            if (document.numOfPapers * numOfCopies > papers)
            {
                throw new PapersException(document.numOfPapers * numOfCopies - papers);
            }
            if (document.numOfPapers * numOfCopies > inkLevel)
            {
                throw new InkException(" Fill the cartridge.");
            }

            Console.WriteLine("Printing...");
        }

        public void FillTheCartridge()
        {
            if (inkLevel>=40)
            {
                throw new Exception("Cartridge is already full!");
            }
            inkLevel = 40;
            Console.WriteLine("Cartridge is filled!");
        }

        public void AddPapers(int papers)
        {
            this.papers += papers;
            Console.WriteLine("You add {0} papers.",papers);
        }

       

        [Serializable]
        public class PapersException : Exception
        {
            public PapersException() { }

            public PapersException(int papers) : base($"Not enough papers for priting! Add at least {papers} papers.") { }
            
        }


        [Serializable]
        public class InkException : Exception
        {
            public InkException() { }           
            public InkException(string message) : base(" Not enough ink for priting!  " + message) { }

            public InkException(string message, Exception inner) : base(message, inner) { }
            protected InkException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
