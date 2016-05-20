// <copyright file="OverlayManager.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Collections.Generic;

    public class OverlayManager
    {
        private Dictionary<string, Action<dynamic>> _Overlays = new Dictionary<string, Action<dynamic>>();

        public void SetOverlay(string key, dynamic args)
        {
            if (_Overlays.ContainsKey(key))
            {
                _Overlays[key].Invoke(args);
            }
        }

        public void RemoveOverlay(string key)
        {
            if (_Overlays.ContainsKey(key))
            {
                _Overlays.Remove(key);
            }
        }

        public void RegisterOverlay(string key, Action<dynamic> action)
        {
            if (!_Overlays.ContainsKey(key))
            {
                _Overlays.Add(key, action);
            }
        }
    }
}