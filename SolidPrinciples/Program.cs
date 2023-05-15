using LiskovBad = SolidPrinciples.LiskovSubstitution.Bad.LiskovSubstitution;
using LiskovGood = SolidPrinciples.LiskovSubstitution.Good.LiskovSubstitution;
using SolidPrinciples.OpenClose.Bad;
using SolidPrinciples.OpenClose.Good;
using SolidPrinciples.SingleResponsibility.Bad;
using SolidPrinciples.SingleResponsibility.Good;

namespace SolidPrinciples
{    
    public class Demo
    {
        static void Main(string[] args)
        {
            // SingleResponsibilityBad.Demo();
            // SingleResponsibilityGood.Demo();

            // OpenCloseBad.Demo();
            // OpenCloseGood.Demo();

            // LiskovBad.Demo();
            LiskovGood.Demo();
        }
    }
}