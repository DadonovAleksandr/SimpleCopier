using System;
using NLog;

namespace SimpleCopier
{
    class Program
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            
            #if DEBUG
            log.Info("Запуск приложения в режиме DEBUG");
            #else
            log.Info("Запуск приложения в режиме RELEASE");
            #endif
            
            var copier = new FileCopier();
            InitRoutes(ref copier);
            CopierProcess(ref copier);
        }

        
        private static void InitRoutes(ref FileCopier copier)
        {
            #if RELEASE
            var sourcePrefix = "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha";
            var destinationPrefix = "C:\\ProjectVU";
            #endif
            #if DEBUG
            
            var sourcePrefix = "W:\\Alpha";
            var destinationPrefix = "X:\\ProjectVU";
            #endif
            try
            {
                // Alarms
            copier.AddRoute(
                $"{sourcePrefix}\\Config\\Alarms\\Alarm_Hist\\presetfilters.xml",
                $"{destinationPrefix}\\Config\\Alarms\\Alarm_Hist\\presetfilters.xml");
            // Tools+
            copier.AddRoute(
                $"{sourcePrefix}\\Config\\Tools+\\OipUst.tcf",
                $"{destinationPrefix}\\Config\\Tools+\\OipUst.tcf");
            copier.AddRoute(
                $"{sourcePrefix}\\Config\\Tools+\\TimeUst.tcf",
                $"{destinationPrefix}\\Config\\Tools+\\TimeUst.tcf");
            // Trends
            copier.AddRoute(
                $"{sourcePrefix}\\Config\\Trends\\Trend_Hist\\TrendsUserTree.xml",
                $"{destinationPrefix}\\Config\\Trends\\Trend_Hist\\TrendsUserTree.xml");
            
            // Maps
            copier.AddRoute(
                $"{sourcePrefix}\\Maps\\АРМ Резервное\\plc_opcua.xml",
                $"{destinationPrefix}\\Maps\\plc_opcua.xml");
            
            // Maps
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_Aggregators.omx",
                $"{destinationPrefix}\\OMXs\\PLC_Aggregators.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_Ai31Sensors.omx",
                $"{destinationPrefix}\\OMXs\\PLC_Ai31Sensors.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_Diag.omx",
                $"{destinationPrefix}\\OMXs\\PLC_Diag.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_FireAPUs.omx",
                $"{destinationPrefix}\\OMXs\\PLC_FireAPUs.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_FireSensors.omx",
                $"{destinationPrefix}\\OMXs\\PLC_FireSensors.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_FireZones.omx",
                $"{destinationPrefix}\\OMXs\\PLC_FireZones.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_KTPRP.omx",
                $"{destinationPrefix}\\OMXs\\PLC_KTPRP.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_KTPRS.omx",
                $"{destinationPrefix}\\OMXs\\PLC_KTPRS.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_Messages.omx",
                $"{destinationPrefix}\\OMXs\\PLC_Messages.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_ODP.omx",
                $"{destinationPrefix}\\OMXs\\PLC_ODP.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_OIPs.omx",
                $"{destinationPrefix}\\OMXs\\PLC_OIPs.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_OIPsKZO.omx",
                $"{destinationPrefix}\\OMXs\\PLC_OIPsKZO.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_UBDs.omx",
                $"{destinationPrefix}\\OMXs\\PLC_UBDs.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_UPTS.omx",
                $"{destinationPrefix}\\OMXs\\PLC_UPTS.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_UVSs.omx",
                $"{destinationPrefix}\\OMXs\\PLC_UVSs.omx");
            copier.AddRoute(
                $"{sourcePrefix}\\OMXs\\PLC_UZD.omx",
                $"{destinationPrefix}\\OMXs\\PLC_UZD.omx");
            }
            catch (Exception e)
            {
                log.Error($"Ошибка при загрузке маршрутов копирования: {e.ToString()}");
                throw;
            }
        }
        
        private static void CopierProcess(ref FileCopier copier)
        {
            try
            {
                Console.WriteLine("SimpleCopier");
                var userAnswer = string.Empty;
                do
                {
                    Console.Write("Input command: ");
                    userAnswer = Console.ReadLine();
                    log.Info($"Получена команда {userAnswer}");
                    switch (userAnswer)
                    {
                        case "copy":
                            log.Info("Выполнение команды копирования");
                            copier.Copy();
                            break;
                        case "exit":
                            log.Info("Выполнение команды завершения работы");
                            return;
                        default:
                            log.Info("Команда не может быть идентифицированна");
                            Console.WriteLine("Command not accepted");
                            break;
                    }
                } while (true);
            }
            catch (Exception e)
            {
                log.Error($"Ошибка при выполнении команды от пользователя: {e.ToString()}");
                throw;
            }
        }

    }
}