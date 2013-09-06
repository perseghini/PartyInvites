using PartyInvites.Models;
using PartyInvites.Models.Repository;
using PartyInvites.Presenters.Results;

namespace PartyInvites.Presenters
{
    public class RsvpPresenter : IPresenter<GuestResponse>
    {
        public IRepository Repository { get; set; }

        public IResult GetResult()
        {
            return new DataResult<GuestResponse>(new GuestResponse());
        }

        public IResult GetResult(GuestResponse requestData)
        {
            Repository.AddResponse(requestData);
            if (requestData.WillAttend != null && requestData.WillAttend.Value)
            {
                return new RedirectResult("/Content/seeyouthere.html");
            }
            else
            {
                return new RedirectResult("/Content/sorryyoucantcome.html");
            }
        }
    }
}