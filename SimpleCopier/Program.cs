using System;

namespace SimpleCopier
{
    class Program
    {
        static void Main(string[] args)
        {
            var copier = new FileCopier();
            InitRoutes(ref copier);
            CopierProcess(ref copier);
        }

        
        private static void InitRoutes(ref FileCopier copier)
        {
            // Alarms
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\Config\\Alarms\\Alarm_Hist\\presetfilters.xml",
                "C:\\ProjectVU\\Config\\Alarms\\Alarm_Hist\\presetfilters.xml");
            // Tools+
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\Config\\Tools+\\OipUst.tcf",
                "C:\\ProjectVU\\Config\\Tools+\\OipUst.tcf");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\Config\\Tools+\\TimeUst.tcf",
                "C:\\ProjectVU\\Config\\Tools+\\TimeUst.tcf");
            // Trends
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\Config\\Trends\\Trend_Hist\\TrendsUserTree.xml",
                "C:\\ProjectVU\\Config\\Trends\\Trend_Hist\\TrendsUserTree.xml");
            
            // Maps
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\Maps\\АРМ Резервное\\plc_opcua.xml",
                "C:\\ProjectVU\\Maps\\plc_opcua.xml");
            
            // Maps
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_Aggregators.omx",
                "C:\\ProjectVU\\OMXs\\PLC_Aggregators.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_Ai31Sensors.omx",
                "C:\\ProjectVU\\OMXs\\PLC_Ai31Sensors.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_Diag.omx",
                "C:\\ProjectVU\\OMXs\\PLC_Diag.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_FireAPUs.omx",
                "C:\\ProjectVU\\OMXs\\PLC_FireAPUs.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_FireSensors.omx",
                "C:\\ProjectVU\\OMXs\\PLC_FireSensors.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_FireZones.omx",
                "C:\\ProjectVU\\OMXs\\PLC_FireZones.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_KTPRP.omx",
                "C:\\ProjectVU\\OMXs\\PLC_KTPRP.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_KTPRS.omx",
                "C:\\ProjectVU\\OMXs\\PLC_KTPRS.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_Messages.omx",
                "C:\\ProjectVU\\OMXs\\PLC_Messages.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_ODP.omx",
                "C:\\ProjectVU\\OMXs\\PLC_ODP.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_OIPs.omx",
                "C:\\ProjectVU\\OMXs\\PLC_OIPs.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_OIPsKZO.omx",
                "C:\\ProjectVU\\OMXs\\PLC_OIPsKZO.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_UBDs.omx",
                "C:\\ProjectVU\\OMXs\\PLC_UBDs.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_UPTS.omx",
                "C:\\ProjectVU\\OMXs\\PLC_UPTS.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_UVSs.omx",
                "C:\\ProjectVU\\OMXs\\PLC_UVSs.omx");
            copier.AddRoute(
                "Z:\\ASU PT\\Configurator\\GUIConfigurator\\bin\\Debug\\Generate\\Alpha\\OMXs\\PLC_UZD.omx",
                "C:\\ProjectVU\\OMXs\\PLC_UZD.omx");
        }
        
        private static void CopierProcess(ref FileCopier copier)
        {
            Console.WriteLine("SimpleCopier");
            var userAnswer = string.Empty;
            do
            {
                Console.Write("Input command: ");
                userAnswer = Console.ReadLine();
                switch (userAnswer)
                {
                    case "copy":
                        copier.Copy();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Command not accepted");
                        break;
                }
            } while (true);
        }

    }
}