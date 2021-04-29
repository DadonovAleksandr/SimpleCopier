using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace SimpleCopier
{
    public class FileCopier
    {
        public List<CopyRoute> Routes;
        public FileCopier()
        {
            Routes = new List<CopyRoute>();
        }

        public void AddRoute(string source, string destination)
        {
            Routes.Add(new CopyRoute(source, destination));
        }

        public void Copy()
        {
            foreach (var r in Routes)
            {
                if (File.Exists(r.Source))
                {
                    File.Copy(r.Source, r.Destination, true);
                }
                else
                {
                    Console.WriteLine($"File {r.Source} does not exist");
                }
            }
        }
    }

    public class CopyRoute
    {
        public string Source { get; set; }
        public string Destination { get; set; }

        public CopyRoute(string src, string dst)
        {
            Source = src;
            Destination = dst;
        }
    }
}