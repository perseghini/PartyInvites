namespace PartyInvites.Presenters.Results
{
    public class RedirectResult : IResult
    {
        private readonly string _url;

        public RedirectResult(string urlValue)
        {
            _url = urlValue;
        }

        public string Url
        {
            get
            {
                return _url;
            }
        }
    }
}