// <copyright file="ScheduleFactory.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XAF.Model
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public static class ScheduleFactory
    {
        public static List<ScheduleDay> Generate()
        {
            return Generate(GenerateSettings());
        }

        public static List<ScheduleDay> Generate(ScheduleSettings settings)
        {
            List<ScheduleDay> days = new List<ScheduleDay>();
            List<int> list = null;
            switch (settings.WeekViewType)
            {
                case WeekViewTypeOption.WorkWeek:
                    list = new List<int>() { 2, 4, 8, 16, 32 };
                    break;

                case WeekViewTypeOption.SevenDays:
                    list = new List<int>() { 1, 2, 4, 8, 16, 32, 64 };
                    break;

                default:
                    break;
            }

            //days.Add(new ScheduleDay(settings));
            foreach (int i in list)
            {
                DaysInWeek dayOfWeek = (DaysInWeek)Enum.Parse(typeof(DaysInWeek), i.ToString(), true);
                days.Add(new ScheduleDay(dayOfWeek, settings));
            }
            return days;
        }

        internal static void GenerateCanvas(Canvas ctl, Canvas hdr, Canvas overLay)
        {
            GenerateCanvas(ctl, hdr, overLay, GenerateSettings());
        }

        internal static void GenerateCanvas(Canvas ctl, Canvas hdr, Canvas overLay, ScheduleSettings settings)
        {
            GenerateBase(ctl, settings);
            List<ScheduleDay> list = Generate(settings);

            //int h = 60 * 24;
            int columns = (settings.WeekViewType == WeekViewTypeOption.SevenDays) ? 7 : 5;
            int x1 = 0 + settings.HorizontalMargin;
            int x2 = 0 + settings.HorizontalMargin;
            int y1 = (settings.VerticalMargin / 4);
            int y2 = Convert.ToInt32(ctl.Height - settings.VerticalMargin / 4);

            int i = 0;
            foreach (var item in list)
            {
                Line hz = new Line() { X1 = settings.HorizontalMargin + (settings.ColumnWidth * i), X2 = settings.HorizontalMargin + (settings.ColumnWidth * i), Y1 = y1, Y2 = y2, StrokeThickness = 1.0, Stroke = Brushes.Cyan };
                ctl.Children.Add(hz);
                TextBlock txheader = new TextBlock() { Text = item.Day.ToString(), Foreground = Brushes.White, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
                double c1 = settings.HeaderHeight * 1.5;
                double c2 = settings.HeaderHeight / 4;
                int headwidth = settings.ColumnWidth * 7 / 8;
                double headwidthsplit = (settings.ColumnWidth - headwidth) / 2;
                Border brd = new Border() { Width = headwidth, Height = settings.HeaderHeight, Background = Brushes.Gray, Child = txheader, Padding = new Thickness(7.0, 3.0, 7.0, 3.0), CornerRadius = new CornerRadius(c1, c1, c2, c2) };
                brd.SetValue(Canvas.TopProperty, 0.0);
                brd.SetValue(Canvas.LeftProperty, Convert.ToDouble(settings.HorizontalMargin + (settings.ColumnWidth * i) + headwidthsplit));

                //Line hzh = new Line() { X1 = settings.HorizontalMargin + (settings.ColumnWidth * i), X2 = settings.HorizontalMargin + (settings.ColumnWidth * i), Y1 = 0, Y2 = settings.HeaderHeight, StrokeThickness = 1.0, Stroke = Brushes.Cyan };
                //hdr.Children.Add(hzh);
                hdr.Children.Add(brd);
                i++;
            }
            Line hze = new Line() { X1 = settings.HorizontalMargin + (settings.ColumnWidth * i), X2 = settings.HorizontalMargin + (settings.ColumnWidth * i), Y1 = y1, Y2 = y2, StrokeThickness = 1.0, Stroke = Brushes.Cyan };
            ctl.Children.Add(hze);
            hdr.Height = settings.HeaderHeight;
            hdr.Width = (settings.ColumnCount * settings.ColumnWidth) + settings.HorizontalMargin;

            overLay.Height = settings.Height;
            overLay.Width = (settings.ColumnCount * settings.ColumnWidth);
            double leftmargin = settings.HorizontalMargin + 17;
            overLay.Margin = new Thickness(leftmargin, 0.0, 0.0, 0.0);
        }

        private static void GenerateBase(Canvas ctl, ScheduleSettings settings)
        {
            ScheduleDay day = new ScheduleDay(DaysInWeek.None, settings);
            int w = settings.ColumnCount * settings.ColumnWidth;
            ctl.Height = settings.Height + (settings.VerticalMargin / 2);
            ctl.Width = w + settings.HorizontalMargin;
            int x1 = settings.HorizontalMargin;
            int x2 = w + settings.HorizontalMargin;
            int y1 = settings.VerticalMargin;
            int y2 = settings.VerticalMargin;
            int y = settings.VerticalMargin;
            int pixelsperblock = settings.Height / day.TimeBlocks.Count;
            foreach (var item in day.TimeBlocks)
            {
                double divisor = ((double)item.StartMinute * ((double)pixelsperblock / (double)settings.MajorTimeBlock)) + ((double)settings.VerticalMargin / 4.0);
                y1 = y2 = Convert.ToInt32(divisor);

                Line l = new Line() { X1 = x1 - 30, X2 = x2, Y1 = y1, Y2 = y2, Stroke = Brushes.Gray, StrokeThickness = 1.0 };
                ctl.Children.Add(l);
                TextBlock txl = new TextBlock() { Text = item.ToString(), Foreground = Brushes.White };
                Border brd = new Border() { Width = 80.0, Background = Brushes.Gray, Child = txl, Padding = new Thickness(7.0, 3.0, 7.0, 3.0), CornerRadius = new CornerRadius(10.0) };
                brd.SetValue(Canvas.TopProperty, Convert.ToDouble(y1 - 12));
                brd.SetValue(Canvas.LeftProperty, Convert.ToDouble(x1 - (settings.HorizontalMargin / 1.0)));
                ctl.Children.Add(brd);

                int pixelsperminorblock = pixelsperblock / item.TimeBlocks.Count;
                for (int i = 1; i < item.TimeBlocks.Count; i++)
                {
                    var subitem = item.TimeBlocks[i];
                    double minordivisor = ((double)subitem.BlockMinute * ((double)pixelsperminorblock / (double)settings.MinorTimeBlock));
                    y1 += Convert.ToInt32(minordivisor);
                    y2 += Convert.ToInt32(minordivisor);
                    Line sl = new Line() { Stroke = Brushes.LightGray, StrokeThickness = 1.0 };
                    sl.X1 = x1;
                    sl.X2 = x2;
                    sl.Y1 = y1;
                    sl.Y2 = y2;
                    ctl.Children.Add(sl);
                    TextBlock subtxl = new TextBlock() { Text = subitem.ToString(), Foreground = Brushes.Gray };
                    subtxl.SetValue(Canvas.TopProperty, Convert.ToDouble(sl.Y1 - 7));
                    subtxl.SetValue(Canvas.LeftProperty, Convert.ToDouble(x1 - 25));
                    ctl.Children.Add(subtxl);
                }
            }
            y1 = settings.Height + (settings.VerticalMargin / 4);
            y2 = settings.Height + (settings.VerticalMargin / 4);
            Line lend = new Line() { X1 = x1 - 30, X2 = x2, Y1 = y1, Y2 = y2, Stroke = Brushes.Gray, StrokeThickness = 1.0 };
            ctl.Children.Add(lend);
            TextBlock txlend = new TextBlock() { Text = "12:00 AM", Foreground = Brushes.White };
            Border brdend = new Border() { Width = 80.0, Background = Brushes.Gray, Child = txlend, Padding = new Thickness(7.0, 3.0, 7.0, 3.0), CornerRadius = new CornerRadius(10.0) };
            brdend.SetValue(Canvas.TopProperty, Convert.ToDouble(y1 - 12));
            brdend.SetValue(Canvas.LeftProperty, Convert.ToDouble(x1 - (settings.HorizontalMargin)));
            ctl.Children.Add(brdend);
        }

        private static ScheduleSettings GenerateSettings()
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

            //settings.MajorTimeBlock = BlockMinuteOption.OneHour;
            //settings.MinorTimeBlock = BlockMinuteOption.FifteenMinutes;
            //settings.WeekViewType = WeekViewTypeOption.WorkWeek;

            settings.MajorTimeBlock = BlockMinuteOption.OneHour;
            settings.MinorTimeBlock = BlockMinuteOption.ThirtyMinutes;
            settings.WeekViewType = WeekViewTypeOption.SevenDays;

            //settings.MajorTimeBlock = BlockMinuteOption.OneHour;
            //settings.MinorTimeBlock = BlockMinuteOption.ThirtyMinutes;
            //settings.WeekViewType = WeekViewTypeOption.WorkWeek;
            return settings;
        }

        internal static double GenerateScrollPosition(int start)
        {
            ScheduleSettings settings = GenerateSettings();
            return start * settings.GetMinutesPerPixel();
        }

        internal static double GenerateScrollPosition(int start, ScheduleSettings settings)
        {
            return start * settings.GetMinutesPerPixel();
        }
    }
}