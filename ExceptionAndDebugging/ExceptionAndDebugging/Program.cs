using System;
using System.Diagnostics;

namespace ExceptionAndDebugging
{
    class Program
    {

        static void Main(string[] args)
        {

#if !DEBUG
                                   
            int pg,cop;
            Console.WriteLine("Insert number of pages in document");
            pg = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert number of copies");
            cop = Convert.ToInt32(Console.ReadLine());
            var printer = new Printer(23, 15);
            var document = new Document(pg);
#endif

#if DEBUG
            var printer = new Printer(23, 15);
            var document = new Document(4);
#endif


            try
            {               
                int menu = 1;
                while (menu == 1)
                {
                    try
                    {
#if !DEBUG
                        printer.Print(document, cop);
#endif
#if DEBUG
                        printer.Print(document, 4);
#endif
                        menu = 0;
                    }
                    catch (Printer.PapersException pex)
                    {
                        
                        Console.WriteLine(pex.Message);
                        printer.AddPapers(45);
                    }
                    catch (Printer.InkException iex)
                    {
                        Console.WriteLine(iex.Message);
                        try
                        {
                            printer.FillTheCartridge();
                        }
                        catch (Exception fex)
                        {
                            Console.WriteLine(fex.Message);
                            Console.WriteLine("Your document is too big for printing!");
                            menu = 0;

                        }
                    }
                    
                }               
            }
            catch (Exception dex)
            {
                throw new Exception ("Invalid document for printing!",dex);
            }
            finally
            {
                document.Close();
            }
           
            
            Console.ReadKey();
        }
    }

}


