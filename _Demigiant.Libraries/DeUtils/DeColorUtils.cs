﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2016/01/11 12:22
// License Copyright (c) Daniele Giardini

// Based on code by mvi for the hex-to-color/color-to-hex conversion: http://wiki.unity3d.com/index.php?title=HexConverter

using System;
using UnityEngine;

namespace DG.DeUtils
{
    public static class DeColorUtils
    {
        /// <summary>
        /// Converts a HEX color to a Unity Color and returns it
        /// </summary>
        /// <param name="hex">The HEX color, either with or without the initial # (accepts both regular and short format)</param>
        [Obsolete("DeRectUtils.HexToColor is deprecated, use the myColor.HexToColor extension instead (in the DeExtensions library).")]
        public static Color HexToColor(string hex)
        {
            if (hex[0] == '#') hex = hex.Substring(1);
            int len = hex.Length;
            bool isShortFormat = len < 6;
            if (isShortFormat) {
                float r = (HexToInt(hex[0]) + HexToInt(hex[0]) * 16f) / 255f;
                float g = (HexToInt(hex[1]) + HexToInt(hex[1]) * 16f) / 255f;
                float b = (HexToInt(hex[2]) + HexToInt(hex[2]) * 16f) / 255f;
                float a = len == 4 ? (HexToInt(hex[3]) + HexToInt(hex[3]) * 16f) / 255f : 1;
                return new Color(r, g, b, a);
            } else {
                float r = (HexToInt(hex[1]) + HexToInt(hex[0]) * 16f) / 255f;
                float g = (HexToInt(hex[3]) + HexToInt(hex[2]) * 16f) / 255f;
                float b = (HexToInt(hex[5]) + HexToInt(hex[4]) * 16f) / 255f;
                float a = len == 8 ? (HexToInt(hex[7]) + HexToInt(hex[6]) * 16f) / 255f : 1;
                return new Color(r, g, b, a);
            }
        }

        /// <summary>
        /// Returns a HEX version of the given Unity Color, without the initial #
        /// </summary>
        [Obsolete("DeRectUtils.ColorToHex is deprecated, use the myColor.ColorToHex extension instead (in the DeExtensions library).")]
        public static string ColorToHex(Color32 color)
        {
            return color.r.ToString("x2") + color.g.ToString("x2") + color.b.ToString("x2");
        }

        /// <summary>
        /// Returns a clone of the given Color with the alpha changed to the given value
        /// </summary>
        [Obsolete("DeRectUtils.SetAlpha is deprecated, use the myColor.SetAlpha extension instead (in the DeExtensions library).")]
        public static Color ChangeAlpha(Color color, float alpha)
        {
            color.a = alpha;
            return color;
        }

        #region Methods

        static int HexToInt(char hexVal)
        {
            return int.Parse(hexVal.ToString(), System.Globalization.NumberStyles.HexNumber);
        }

        #endregion
    }
}