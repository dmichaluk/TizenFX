/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace ElmSharp
{
    /// <summary>
    /// The Background is a widget that use for setting (solid) background decorations to a window (unless it has transparency enabled)
    /// or to any container object.
    /// </summary>
    public class Background : Layout
    {
        /// <summary>
        /// Creates and initializes a new instance of the Background class.
        /// </summary>
        /// <param name="parent">The EvasObject to which the new Background will be attached as a child.</param>
        public Background(EvasObject parent) : base(parent)
        {
            Style = "transparent";
        }

        /// <summary>
        /// Sets or gets color to Background.
        /// </summary>
        public override Color Color
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                var swallowContent = GetPartContent("elm.swallow.rectangle");
                if (swallowContent != IntPtr.Zero)
                {
                    Interop.Evas.evas_object_color_get(swallowContent, out r, out g, out b, out a);
                }
                return new Color(r, g, b, a);
            }
            set
            {
                var swallowContent = GetPartContent("elm.swallow.rectangle");
                if (swallowContent == IntPtr.Zero)
                {
                    Interop.Elementary.elm_bg_color_set(RealHandle, value.R, value.G, value.B);
                    swallowContent = GetPartContent("elm.swallow.rectangle");
                }
                Interop.Evas.evas_object_color_set(swallowContent, value.R, value.G, value.B, value.A);
            }
        }

        /// <summary>
        /// Sets or gets image to Background.
        /// </summary>
        public string File
        {
            get
            {
                return Interop.Elementary.BackgroundFileGet(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_bg_file_set(RealHandle, value, IntPtr.Zero);
            }
        }

        /// <summary>
        /// Sets or gets the mode of display for a given background widget's image.
        /// </summary>
        /// <remarks>
        /// This sets how the background widget will display its image.
        /// This will only work if the File was previously set with an image file on obj.
        /// The image can be display tiled, scaled, centered or stretched. scaled by default.
        /// </remarks>
        public BackgroundOptions BackgroundOption
        {
            get
            {
                return (BackgroundOptions)Interop.Elementary.elm_bg_option_get(RealHandle);
            }
            set
            {
                Interop.Elementary.elm_bg_option_set(RealHandle, (Interop.Elementary.BackgroundOptions)value);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_layout_add(parent.Handle);
            Interop.Elementary.elm_layout_theme_set(handle, "layout", "elm_widget", "default");

            RealHandle = Interop.Elementary.elm_bg_add(handle);
            Interop.Elementary.elm_object_part_content_set(handle, "elm.swallow.content", RealHandle);

            return handle;
        }
    }

    /// <summary>
    /// Enumeration for the background type.
    /// </summary>
    public enum BackgroundOptions
    {
        /// <summary>
        /// Centers the background image
        /// </summary>
        Center,
        /// <summary>
        /// Scales the background image, retaining the aspect ratio
        /// </summary>
        Scale,
        /// <summary>
        /// Stretches the background image to fill the UI component's area.
        /// </summary>
        Stretch,
        /// <summary>
        /// Tiles the background image at its original size
        /// </summary>
        Tile
    }
}
