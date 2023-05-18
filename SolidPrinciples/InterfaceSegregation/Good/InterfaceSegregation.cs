using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.InterfaceSegregation.Good
{
    public class Document
    {
    }

    public interface IPrinter
    {
        void Print(Document document);
    }

    public interface IScanner
    {
        void Scan(Document document);
    }

    public interface IFax
    {
        void Fax(Document document);
    }

    public interface IMultiFunctionDervice : IFax,IPrinter,IScanner
    {
    }

    internal class MultiFunctionPrinter : IMultiFunctionDervice
    {
        private readonly IPrinter printer;
        private readonly IScanner scanner;
        private readonly IFax fax;

        public MultiFunctionPrinter(IPrinter printer, IScanner scanner, IFax fax)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(paramName: nameof(printer));
            }

            if (fax == null)
            {
                throw new ArgumentNullException(paramName: nameof(fax));
            }

            if (scanner == null)
            {
                throw new ArgumentNullException(paramName: nameof(scanner));
            }

            this.fax = fax;
            this.printer = printer;
            this.scanner = scanner;
        }

        public void Fax(Document document)
        {
            // Do Fax
            fax.Fax(document);
        }

        public void Print(Document document)
        {
            // Do Print
            printer.Print(document);
        }

        public void Scan(Document document)
        {
            // Do Scan
            scanner.Scan(document);
        } // decorator pattern
    }

    internal class PhotoCopier : IPrinter, IScanner
    {
        public void Print(Document document)
        {
            // Do Print
        }

        public void Scan( Document document)
        {
            // Do Scan
        }
    }

    internal class OldFashionedPrinter : IPrinter
    {
        public void Print(Document document)
        {
            // Do Print
        }
    }

    internal class InterfaceSegregation
    {
        public static void Demo()
        {

        }
    }
}
