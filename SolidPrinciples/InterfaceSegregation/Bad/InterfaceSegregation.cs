using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.InterfaceSegregation.Bad
{
    public class Document
    {
    }

    public interface IMachine
    {
        void Print(Document document);

        void Scan(Document document);

        void Fax(Document document);
    }

    internal class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document document)
        {
            // Do Fax
        }

        public void Print(Document document)
        {
            // Do Print
        }

        public void Scan(Document document)
        {
            // Do Scan
        }
    }

    internal class OldFashionedPrinter : IMachine
    {
        public void Fax(Document document)
        {
            throw new NotImplementedException();
        }

        public void Print(Document document)
        {
            // Do Print
        }

        public void Scan(Document document)
        {
            throw new NotImplementedException();
        }
    }

    internal class InterfaceSegregation
    {
        public static void Demo()
        {
            
        }
    }
}
