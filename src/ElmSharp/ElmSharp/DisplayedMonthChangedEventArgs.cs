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
    /// It inherits System.EventArgs.
    /// The DisplayedMonthChangedEvent in Calendar contain
    /// DisplayedMonthChangedEventArgs as a parameter.
    /// </summary>
    public class DisplayedMonthChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the OldMonth property of the given DisplayedMonthChangedEventArgs.
        /// </summary>
        public int OldMonth { get; private set; }

        /// <summary>
        /// Gets the NewMonth property of the given DisplayedMonthChangedEventArgs.
        /// </summary>
        public int NewMonth { get; private set; }

        /// <summary>
        /// Creates and initializes a new instance of the DisplayedMonthChangedEventArgs class.
        /// </summary>
        /// <param name="oldMonth">
        /// old month of date when DisplayedMonthChangedEvent triggered.
        /// </param>
        /// <param name="newMonth">
        /// new month of date when DisplayedMonthChangedEvent triggered.
        /// </param>
        public DisplayedMonthChangedEventArgs(int oldMonth, int newMonth)
        {
            this.OldMonth = oldMonth;
            this.NewMonth = newMonth;
        }
    }
}
