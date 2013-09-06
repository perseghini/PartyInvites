namespace PartyInvites.Presenters.Results
{
    public class DataResult<T> : IResult
    {
        private readonly T _dataItem;

        public DataResult(T data)
        {
            _dataItem = data;
        }

        public T DataItem
        {
            get
            {
                return _dataItem;
            }
        }
    }
}