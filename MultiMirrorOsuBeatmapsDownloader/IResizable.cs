﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiMirrorOsuBeatmapsDownloader
{
    interface IResizable
    {
        void Close();
        void Maximize();
        void Minimize();
    }
}
