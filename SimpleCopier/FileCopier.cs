using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using NLog;

namespace SimpleCopier
{
    public class FileCopier
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        
        public List<CopyRoute> Routes;
        public FileCopier()
        {
            log.Trace("Инициализация объекта FileCopier");
            Routes = new List<CopyRoute>();
        }

        public void AddRoute(string source, string destination)
        {
            log.Trace($"Добавление маршрута копирования: {source} -> {destination}");
            Routes.Add(new CopyRoute(source, destination));
        }

        public void Copy()
        {
            foreach (var r in Routes)
            {
                if (File.Exists(r.Source))
                {
                    log.Trace($"Копирование {r.Source} -> {r.Destination}");
                    File.Copy(r.Source, r.Destination, true);
                }
                else
                {
                    log.Error($"Файл {r.Source} не существует");
                    Console.WriteLine($"File {r.Source} does not exist");
                }
            }
        }
    }

    public class CopyRoute
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        public string Source { get; set; }
        public string Destination { get; set; }

        public CopyRoute(string src, string dst)
        {
            log.Trace("Инициализация объекта CopyRoute");
            Source = src;
            Destination = dst;
        }
    }
}