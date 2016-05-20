// <copyright file="MinorTimeBlock.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XAF.Model
{
    using System;

    public class MinorTimeBlock
    {
        public int StartMinute { get; set; }

        public int Height { get; set; }

        public BlockMinuteOption MajorBlockMinute { get; set; }

        public BlockMinuteOption BlockMinute { get; set; }

        public bool IsDay { get; set; }

        public MinorTimeBlock(BlockMinuteOption blockMinute, int startMinute, bool isDay, BlockMinuteOption majorBlockMinute)
        {
            BlockMinute = blockMinute;
            StartMinute = startMinute;
            IsDay = isDay;
            MajorBlockMinute = majorBlockMinute;
        }

        public override string ToString()
        {
            DateTime date = DateTime.Now.Date.AddMinutes(StartMinute);

            //return String.Format(":{0:mm}", date);
            int j = (int)MajorBlockMinute;
            if (j > 60)
            {
                int i = (int)BlockMinute;
                if (i >= 60 && i % 60 == 0)
                {
                    return String.Format("{0:h tt}", date);
                }
                else if (i < 60)
                {
                    return String.Format("{0:h:mm}", date);
                }
                else
                {
                    return String.Format("{0:h:mm}", date);
                }
            }
            else
            {
                return String.Format(":{0:mm}", date);
            }
        }
    }
}