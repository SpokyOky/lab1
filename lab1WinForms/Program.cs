﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1WinForms
{
    public delegate void warshipDelegate(ITransport warship);
    public delegate void airplanesDelegate(IAirplanes airplanes);

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormAircraftCarrier());
            Application.Run(new FormDocks());
        }
    }
}
