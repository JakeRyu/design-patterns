using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SRP
{
    class Journal
    {
        private readonly List<string> entries = new List<string>();
        private int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void Remove(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString(){
            return string.Join(Environment.NewLine, entries);
        }

    }

    // handles the responsibility of persisting objects
    class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if(overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            journal.AddEntry("I am sad");
            journal.AddEntry("I ate a bug");

            System.Console.WriteLine(journal);
        }
    }
}
