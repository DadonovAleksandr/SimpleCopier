using System.Collections;
using System.Collections.Generic;
using System.IO;
using NLog;
using SimpleCopier.Service;

namespace SimpleCopier
{
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

    public class CopyRoutes : IEnumerable
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private string _fileName;
        
        public List<CopyRoute> Routes;

        public CopyRoutes(string fileName)
        {
            _fileName = fileName;
            if (!File.Exists(_fileName))
                Init();
            var jsonProvider = new JsonFileProvider<List<CopyRoute>>();
            Routes = jsonProvider.Load(_fileName);
        }

        

        public void Save()
        {
            var jsonProvider = new JsonFileProvider<List<CopyRoute>>();
            jsonProvider.Save(Routes, _fileName);
        }

        public void Add(string src, string dst)
        {
            Routes.Add(new CopyRoute(src, dst));
        }


        public IEnumerator GetEnumerator()
        {
            foreach (var r in Routes)
            {
                yield return r;
            }
        }

        public IEnumerable GetEnumerable()
        {
            foreach (var r in Routes)
            {
                yield return r;
            }
        }
        
        //TODO: Убрать при реализации GUI
        private void Init()
        {
            Routes = new List<CopyRoute>();
            
            #if RELEASE
            var sourcePrefix = "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha";
            var destinationPrefix = "C:\\ProjectVU";
            #endif
            #if DEBUG
            
            var sourcePrefix = "W:\\Alpha";
            var destinationPrefix = "X:\\ProjectVU";
            #endif
            
            // Alarms
            Add(
                $"{sourcePrefix}\\Config\\Alarms\\Alarm_Hist\\presetfilters.xml",
                $"{destinationPrefix}\\Config\\Alarms\\Alarm_Hist\\presetfilters.xml");
            // Tools+
            Add(
                $"{sourcePrefix}\\Config\\Tools+\\OipUst.tcf",
                $"{destinationPrefix}\\Config\\Tools+\\OipUst.tcf");
            Add(
                $"{sourcePrefix}\\Config\\Tools+\\TimeUst.tcf",
                $"{destinationPrefix}\\Config\\Tools+\\TimeUst.tcf");
            // Trends
            Add(
                $"{sourcePrefix}\\Config\\Trends\\Trend_Hist\\TrendsUserTree.xml",
                $"{destinationPrefix}\\Config\\Trends\\Trend_Hist\\TrendsUserTree.xml");
            
            // Maps
            Add(
                $"{sourcePrefix}\\Maps\\АРМ Резервное\\plc_opcua.xml",
                $"{destinationPrefix}\\Maps\\plc_opcua.xml");
            
            // Maps
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_Aggregators.omx",
                $"{destinationPrefix}\\OMXs\\PLC_Aggregators.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_Ai31Sensors.omx",
                $"{destinationPrefix}\\OMXs\\PLC_Ai31Sensors.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_Diag.omx",
                $"{destinationPrefix}\\OMXs\\PLC_Diag.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_FireAPUs.omx",
                $"{destinationPrefix}\\OMXs\\PLC_FireAPUs.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_FireSensors.omx",
                $"{destinationPrefix}\\OMXs\\PLC_FireSensors.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_FireZones.omx",
                $"{destinationPrefix}\\OMXs\\PLC_FireZones.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_KTPRP.omx",
                $"{destinationPrefix}\\OMXs\\PLC_KTPRP.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_KTPRS.omx",
                $"{destinationPrefix}\\OMXs\\PLC_KTPRS.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_Messages.omx",
                $"{destinationPrefix}\\OMXs\\PLC_Messages.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_ODP.omx",
                $"{destinationPrefix}\\OMXs\\PLC_ODP.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_OIPs.omx",
                $"{destinationPrefix}\\OMXs\\PLC_OIPs.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_OIPsKZO.omx",
                $"{destinationPrefix}\\OMXs\\PLC_OIPsKZO.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_UBDs.omx",
                $"{destinationPrefix}\\OMXs\\PLC_UBDs.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_UPTS.omx",
                $"{destinationPrefix}\\OMXs\\PLC_UPTS.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_UVSs.omx",
                $"{destinationPrefix}\\OMXs\\PLC_UVSs.omx");
            Add(
                $"{sourcePrefix}\\OMXs\\PLC_UZD.omx",
                $"{destinationPrefix}\\OMXs\\PLC_UZD.omx");
            
            Save();
        }
    }
}