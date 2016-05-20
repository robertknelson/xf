// <copyright file="ScheduleSettings.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XAF.Model
{
    using System;

    public class ScheduleSettings
    {
        public WeekViewTypeOption WeekViewType { get; set; }

        public BlockMinuteOption MajorTimeBlock { get; set; }

        public BlockMinuteOption MinorTimeBlock { get; set; }

        public int VerticalMargin { get; set; }

        public int HorizontalMargin { get; set; }

        public int ColumnWidth { get; set; }

        public int Height { get; set; }

        public int ColumnCount { get { return (WeekViewType == WeekViewTypeOption.SevenDays) ? 7 : 5; } }

        public int HeaderHeight { get; set; }

        internal double GetLeft(DaysInWeek day)
        {
            int factor = 0;
            switch (day)
            {
                case DaysInWeek.None:
                    break;

                case DaysInWeek.Sunday:
                    factor = (WeekViewType == WeekViewTypeOption.SevenDays) ? 1 : 0;
                    break;

                case DaysInWeek.Monday:
                    factor = (WeekViewType == WeekViewTypeOption.SevenDays) ? 2 : 1;
                    break;

                case DaysInWeek.Tuesday:
                    factor = (WeekViewType == WeekViewTypeOption.SevenDays) ? 3 : 2;
                    break;

                case DaysInWeek.Wednesday:
                    factor = (WeekViewType == WeekViewTypeOption.SevenDays) ? 4 : 3;
                    break;

                case DaysInWeek.Thursday:
                    factor = (WeekViewType == WeekViewTypeOption.SevenDays) ? 5 : 4;
                    break;

                case DaysInWeek.Friday:
                    factor = (WeekViewType == WeekViewTypeOption.SevenDays) ? 6 : 5;
                    break;

                case DaysInWeek.Saturday:
                    factor = (WeekViewType == WeekViewTypeOption.SevenDays) ? 7 : 0;
                    break;

                default:
                    break;
            }
            if (factor > 0)
            {
                factor--;
            }
            return Convert.ToDouble(factor * ColumnWidth);
        }

        internal double GetMinutesPerPixel()
        {
            return Convert.ToDouble(Height) / 1440;
        }

        internal int GetHeight(int minutes)
        {
            double minutesperpixel = GetMinutesPerPixel();
            return Convert.ToInt32(minutesperpixel * minutes);
        }

        internal double GetTop(int start)
        {
            double minutesperpixel = GetMinutesPerPixel();
            return minutesperpixel * start;
        }

        public static ScheduleSettings GenerateDefault()
        {
            ScheduleSettings settings = new ScheduleSettings();
            settings.VerticalMargin = 50;
            settings.HorizontalMargin = 100;
            settings.ColumnWidth = 124;
            settings.Height = 45 * 24;
            settings.HeaderHeight = 25;

            //settings.MajorTimeBlock = BlockMinuteOption.OneHour;
            //settings.MinorTimeBlock = BlockMinuteOption.FiveMinutes;
            //settings.WeekViewType = WeekViewTypeOption.WorkWeek;

            settings.MajorTimeBlock = BlockMinuteOption.OneHour;
            settings.MinorTimeBlock = BlockMinuteOption.FifteenMinutes;
            settings.WeekViewType = WeekViewTypeOption.WorkWeek;

            //settings.MajorTimeBlock = BlockMinuteOption.OneHour;
            //settings.MinorTimeBlock = BlockMinuteOption.ThirtyMinutes;
            //settings.WeekViewType = WeekViewTypeOption.SevenDays;

            //settings.MajorTimeBlock = BlockMinuteOption.OneHour;
            //settings.MinorTimeBlock = BlockMinuteOption.ThirtyMinutes;
            //settings.WeekViewType = WeekViewTypeOption.WorkWeek;
            return settings;
        }
    }
}