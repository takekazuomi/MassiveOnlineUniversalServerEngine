﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MOUSE.Core;
using NLog;
using RakNetWrapper;


namespace MOUSE.ConsoleHost
{
    static class Program
    {
        public static Logger Log = LogManager.GetLogger("ConsoleHost");

        static void Main(string[] args)
        {
            Log.Info("Started");
            try
            {
                var node = new Node("127.0.0.1", 4567, 1000, 100000, 1);
                node.Start();

                while (true)
                {
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Log.FatalException("Critical Error, Host will be closed", ex);
            }
            Log.Info("Exited");
        }
    }
}
