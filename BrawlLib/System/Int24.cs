﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct Int24
    {
        public byte _dat0, _dat1, _dat2;

        public byte this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return _dat0;
                    case 1: return _dat1;
                    case 2: return _dat2;
                    default: return 0;
                }
            }
            set
            {
                switch (index)
                {
                    case 0: _dat0 = value; break;
                    case 1: _dat1 = value; break;
                    case 2: _dat2 = value; break;
                }
            }
        }

        public int Value
        {
            get { return ((int)_dat0 << 16) | ((int)_dat1 << 8) | ((int)_dat2); }
            set
            {
                _dat2 = (byte)((value) & 0xFF);
                _dat1 = (byte)((value >> 8) & 0xFF);
                _dat0 = (byte)((value >> 16) & 0xFF);
            }
        }

        public static explicit operator int(Int24 val) { return val.Value; }
        public static explicit operator Int24(int val) { return new Int24(val); }
        public static explicit operator uint(Int24 val) { return (uint)val.Value; }
        public static explicit operator Int24(uint val) { return new Int24((int)val); }

        public Int24(int value)
        {
            _dat2 = (byte)((value) & 0xFF);
            _dat1 = (byte)((value >> 8) & 0xFF);
            _dat0 = (byte)((value >> 16) & 0xFF);
        }

        public Int24(byte v0, byte v1, byte v2)
        {
            _dat2 = v2;
            _dat1 = v1;
            _dat0 = v0;
        }

        public VoidPtr Address { get { fixed (void* ptr = &this)return ptr; } }
    }
}
