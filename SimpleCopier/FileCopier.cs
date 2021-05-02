using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using NLog;

namespace SimpleCopier
{
    /// <summary>
    /// Файловый копир
    /// </summary>
    public class FileCopier
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        
        public CopyRoutes Routes;
        public FileCopier()
        {
            log.Trace("Инициализация объекта FileCopier");
            Routes = new CopyRoutes("routes.json");
        }

        public void AddRoute(string source, string destination)
        {
            log.Trace($"Добавление маршрута копирования: {source} -> {destination}");
            Routes.Add(source, destination);
        }

        public void Copy()
        {
            foreach (var r in Routes)
            {
                var cr = (CopyRoute)r;
                if (File.Exists(cr.Source))
                {
                    log.Trace($"Копирование {cr.Source} -> {cr.Destination}");
                    File.Copy(cr.Source, cr.Destination, true);
                }
                else
                {
                    log.Error($"Файл {cr.Source} не существует");
                    Console.WriteLine($"File {cr.Source} does not exist");
                }
            }
        }
    }
}