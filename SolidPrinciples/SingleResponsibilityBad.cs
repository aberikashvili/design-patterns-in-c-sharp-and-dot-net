using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SolidPrinciples.Bad
{
    /**
     * Violating Single Responsibility Principle
     * Because we are adding too much responsibilities to Journal class
     * Not only keeping entries
     * BUT
     * Also managing persistence
     */
    internal class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count} {text}");
            return count++; // memento pattern
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        public void Save(string filename)
        {
            File.WriteAllText(ToString(), filename);
        }

        public static Journal Load(string filename)
        {
            throw new NotImplementedException();
        }

        public void Load(Uri uri)
        {

        }
    }

    internal class SingleResponsibilityBad
    {
        public static void Demo()
        {
            var j = new Journal();
            j.AddEntry("Hello");
            j.AddEntry("World");

            WriteLine(j);
        }
    }
}
