﻿using System;
using System.Collections;
using System.Drawing;

namespace ImageMozaic
{
    public class Imageinformation
    {
        public Color AverageTL { get; set; }
        public Color AverageTR { get; set; }
        public Color AverageBL { get; set; }
        public Color AverageBR { get; set; }
        public string Path { get; set; }
        private ArrayList _data;
        public ArrayList Data
        {
            get
            {
                if (_data == null)
                    _data = new ArrayList();

                return _data;
            }
            set
            {
                if (_data == null)
                    _data = new ArrayList();

                _data = value;
            }
        }

        public Imageinformation(string filePath)
        {
            this.Path = filePath;
        }
    }
}
