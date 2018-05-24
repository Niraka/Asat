using System;
using System.Collections.Generic;

namespace Asat.Tools
{
    public class Sorting
    {
        public enum Directions
        {
            ASCENDING,
            DESCENDING
        }

        public static void ByDate(ref List<DateTime> dates, Directions direction)
        {
            switch (direction)
            {
                case Directions.ASCENDING:
                    dates.Sort(new DateCompareAscending());
                    break;
                case Directions.DESCENDING:
                    dates.Sort(new DateCompareDescending());
                    break;
            }
        }

        public static void ByPairFirst<DataType1, DataType2>(ref List<Pair<DataType1, DataType2>> pairs, Directions direction) where DataType1 : IComparable
        {
            switch (direction)
            {
                case Directions.ASCENDING:
                    pairs.Sort(new PairFirstCompareAscending<DataType1, DataType2>());
                    break;
                case Directions.DESCENDING:
                    pairs.Sort(new PairFirstCompareDescending<DataType1, DataType2>());
                    break;
            }
        }

        public static void ByPairSecond<DataType1, DataType2>(ref List<Pair<DataType1, DataType2>> pairs, Directions direction) where DataType2 : IComparable
        {
            switch (direction)
            {
                case Directions.ASCENDING:
                    pairs.Sort(new PairSecondCompareAscending<DataType1, DataType2>());
                    break;
                case Directions.DESCENDING:
                    pairs.Sort(new PairSecondCompareDescending<DataType1, DataType2>());
                    break;
            }
        }

        private class DateCompareAscending : IComparer<DateTime>
        {
            public int Compare(DateTime x, DateTime y)
            {
                long iDifference = (x.Ticks - y.Ticks);
                return iDifference > 0 ? 1 : iDifference < 0 ? -1 : 0;
            }
        }
        
        private class DateCompareDescending : IComparer<DateTime>
        {
            public int Compare(DateTime x, DateTime y)
            {
                long iDifference = (y.Ticks - x.Ticks);
                return iDifference > 0 ? 1 : iDifference < 0 ? -1 : 0;
            }
        }

        private class PairFirstCompareAscending<DataType1, DataType2> : IComparer<Pair<DataType1, DataType2>> where DataType1 : IComparable
        {
            public int Compare(Pair<DataType1, DataType2> x, Pair<DataType1, DataType2> y)
            {
                return x.First.CompareTo(y);
            }
        }

        private class PairFirstCompareDescending<DataType1, DataType2> : IComparer<Pair<DataType1, DataType2>> where DataType1 : IComparable
        {
            public int Compare(Pair<DataType1, DataType2> x, Pair<DataType1, DataType2> y)
            {
                return y.First.CompareTo(x);
            }
        }

        private class PairSecondCompareAscending<DataType1, DataType2> : IComparer<Pair<DataType1, DataType2>> where DataType2 : IComparable
        {
            public int Compare(Pair<DataType1, DataType2> x, Pair<DataType1, DataType2> y)
            {
                return x.Second.CompareTo(y);
            }
        }

        private class PairSecondCompareDescending<DataType1, DataType2> : IComparer<Pair<DataType1, DataType2>> where DataType2 : IComparable
        {
            public int Compare(Pair<DataType1, DataType2> x, Pair<DataType1, DataType2> y)
            {
                return y.Second.CompareTo(x);
            }
        }
    }
}
