﻿using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    internal class VideoManagement : IVideoManagement
    {
        private readonly VlcManager myManager;
        private readonly VlcMediaPlayerInstance myMediaPlayer;

        public VideoManagement(VlcManager manager, VlcMediaPlayerInstance mediaPlayerInstance)
        {
            myManager = manager;
            myMediaPlayer = mediaPlayerInstance;
            Tracks = new VideoTracksManagement(manager, mediaPlayerInstance);
            Marquee = new MarqueeManagement(manager, mediaPlayerInstance);
            Logo = new LogoManagement(manager, mediaPlayerInstance);
            Adjustments = new AdjustmentsManagement(manager, mediaPlayerInstance);
            IsMouseInputDisabled = false;
            IsKeyInputDisabled = false;
        }
        
        public string AspectRatio
        {
            get { return myManager.GetVideoAspectRatio(myMediaPlayer); }
            set { myManager.SetVideoAspectRatio(myMediaPlayer, value); }
        }

        public string CropGeometry
        {
            get { return myManager.GetVideoCropGeometry(myMediaPlayer);  }
            set { myManager.SetVideoCropGeometry(myMediaPlayer, value); }
        }

        public int Teletext
        {
            get { return myManager.GetVideoTeletext(myMediaPlayer); }
            set { myManager.SetVideoTeletext(myMediaPlayer, value); }
        }

        public ITracksManagement Tracks { get; private set; }

        public string Deinterlace
        {
            set { myManager.SetVideoDeinterlace(myMediaPlayer, value); }
        }

        public IMarqueeManagement Marquee { get; private set; }
        public ILogoManagement Logo { get; private set; }
        public IAdjustmentsManagement Adjustments { get; private set; }

        public bool IsMouseInputDisabled
        {
            set { myManager.SetMouseInput(myMediaPlayer, value); }
        }

        public bool IsKeyInputDisabled
        {
            set { myManager.SetKeyInput(myMediaPlayer, value); }
        }
    }
}
