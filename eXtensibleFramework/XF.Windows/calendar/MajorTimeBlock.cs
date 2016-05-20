// <copyright file="MajorTimeBlock.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XAF.Model
{
    using System;
    using System.Collections.Generic;

    public class MajorTimeBlock
    {
        public int StartMinute { get; set; }

        public int Height { get; set; }

        public BlockMinuteOption BlockMinute { get; set; }

        public VisibilityTypeOption Visibility { get; set; }

        public bool IsDay { get; set; }

        public List<MinorTimeBlock> TimeBlocks { get; set; }

        public MajorTimeBlock(ScheduleSettings settings, int startMinute, bool isDay)
        {
            IsDay = isDay;
            BlockMinute = settings.MajorTimeBlock;
            StartMinute = startMinute;
            int minutes = (int)settings.MinorTimeBlock;
            int numberOfBlocks = (int)settings.MajorTimeBlock / minutes;
            int minorstart = startMinute;
            TimeBlocks = new List<MinorTimeBlock>();
            for (int i = 0; i < numberOfBlocks; i++)
            {
                TimeBlocks.Add(new MinorTimeBlock(settings.MinorTimeBlock, minorstart, isDay, BlockMinute));
                minorstart += minutes;
            }
        }

        public override string ToString()
        {
            DateTime date = DateTime.Now.Date.AddMinutes(StartMinute);

            //DateTime second = date.AddMinutes((int)BlockMinute);
            //return String.Format("From {0} to {1}", date.ToShortTimeString(), second.ToShortTimeString());
            return date.ToShortTimeString();
        }
    }
}