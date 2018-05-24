using System;
using System.Collections.Generic;

namespace Asat.Tools
{
    /// <summary>
    /// A mutable pair of values of the specified type.
    /// </summary>
    /// <typeparam name="DataType"></typeparam>
    public class Pair<DataType>
    {
        public DataType First;
        public DataType Second;

        public Pair()
        {
            Reset();
        }

        public Pair(DataType both)
        {
            this.First = both;
            this.Second = both;
        }

        public Pair(DataType first, DataType second)
        {
            this.First = first;
            this.Second = second;
        }

        public void Reset()
        {
            First = default(DataType);
            Second = default(DataType);
        }

        public static implicit operator Pair<DataType>(KeyValuePair<DataType, DataType> pair)
        {
            return new Pair<DataType>(pair.Key, pair.Value);
        }
        public static implicit operator Pair<DataType>(Tuple<DataType, DataType> pair)
        {
            return new Pair<DataType>(pair.Item1, pair.Item2);
        }
        public static implicit operator KeyValuePair<DataType, DataType>(Pair<DataType> pair)
        {
            return new KeyValuePair<DataType, DataType>(pair.First, pair.Second);
        }
        public static implicit operator Tuple<DataType, DataType>(Pair<DataType> pair)
        {
            return new Tuple<DataType, DataType>(pair.First, pair.Second);
        }
    }

    /// <summary>
    /// A mutable pair of values of the specified types.
    /// </summary>
    /// <typeparam name="DataType1"></typeparam>
    /// <typeparam name="DataType2"></typeparam>
    public class Pair<DataType1, DataType2>
    {
        public DataType1 First;
        public DataType2 Second;

        public Pair()
        {
            Reset();
        }

        public Pair(DataType1 first, DataType2 second)
        {
            this.First = first;
            this.Second = second;
        }

        public void Reset()
        {
            First = default(DataType1);
            Second = default(DataType2);
        }

        public static implicit operator Pair<DataType1, DataType2>(KeyValuePair<DataType1, DataType2> pair)
        {
            return new Pair<DataType1, DataType2>(pair.Key, pair.Value);
        }

        public static implicit operator Pair<DataType1, DataType2>(Tuple<DataType1, DataType2> pair)
        {
            return new Pair<DataType1, DataType2>(pair.Item1, pair.Item2);
        }

        public static implicit operator KeyValuePair<DataType1, DataType2>(Pair<DataType1, DataType2> pair)
        {
            return new KeyValuePair<DataType1, DataType2>(pair.First, pair.Second);
        }

        public static implicit operator Tuple<DataType1, DataType2>(Pair<DataType1, DataType2> pair)
        {
            return new Tuple<DataType1, DataType2>(pair.First, pair.Second);
        }
    }
}
