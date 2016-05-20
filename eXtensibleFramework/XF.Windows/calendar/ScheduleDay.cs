// <copyright file="ScheduleDay.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XAF.Model
{
    using System.Collections.Generic;

    public class ScheduleDay
    {
        public string Title { get; set; }

        public DaysInWeek Day { get; set; }

        public List<MajorTimeBlock> TimeBlocks { get; set; }

        public ScheduleDay(ScheduleSettings settings)
        {
            Title = "Marker";

            int minutes = (int)settings.MajorTimeBlock;
            int numberOfBlocks = 1440 / minutes;
            TimeBlocks = new List<MajorTimeBlock>();
            for (int i = 0; i < numberOfBlocks; i++)
            {
                int marker = i * minutes;
                TimeBlocks.Add(new MajorTimeBlock(settings, marker, false));
            }
        }

        public ScheduleDay(DaysInWeek dayOfWeek, ScheduleSettings settings)
        {
            Day = dayOfWeek;
            int minutes = (int)settings.MajorTimeBlock;
            int numberOfBlocks = 1440 / minutes;
            TimeBlocks = new List<MajorTimeBlock>();
            for (int i = 0; i < numberOfBlocks; i++)
            {
                int marker = i * minutes;
                TimeBlocks.Add(new MajorTimeBlock(settings, marker, true));
            }
        }

        public override string ToString()
        {
            return Day.ToString();
        }
    }
}