﻿using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        //Must be called before the stream has started playing
        public void SetKeyInput(VlcMediaPlayerInstance mediaPlayerInstance, bool on)
        {
            if (mediaPlayerInstance == IntPtr.Zero)
                throw new ArgumentException("Media player instance is not initialized.");
            GetInteropDelegate<SetKeyInput>().Invoke(mediaPlayerInstance, on ? 1u : 0u);
        }
    }
}