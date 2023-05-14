using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SolidPrinciples.Good
{
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
    }

    /**
     * We did Separation of Concerns
     * Persistence class is converned with saving whatever object is being fed
     */
    internal class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }

    internal class SingleResponsibilityGood
    {
        public static void Demo()
        {
            var j = new Journal();
            j.AddEntry("Hello");
            j.AddEntry("World");

            WriteLine(j);

            var p = new Persistence();
            var filename = Path.Combine(Environment.CurrentDirectory, "journal.txt");
            p.SaveToFile(j, filename, true);

            Process.Start(filename); // throws error
        }
    }
}
