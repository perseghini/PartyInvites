using System.Collections.Generic;
using PartyInvites.Models;
using PartyInvites.Models.Repository;
using PartyInvites.Presenters.Results;

namespace PartyInvites.Presenters
{
    public class RsvpPresenter : IPresenter<GuestResponse>, IPresenter<IEnumerable<GuestResponse>>
    {
        [Ninject.Inject]
        public IRepository Repository { get; set; }

        public IResult GetResult()
        {
            return new DataResult<GuestResponse>(new GuestResponse());
        }

        public IResult GetResult(GuestResponse requestData)
        {
            Repository.AddResponse(requestData);
            if (!requestData.WillAttend.HasValue)
            {
                throw new System.ArgumentNullException("WillAttend");
            }
            else if (requestData.WillAttend.Value)
            {
                return new RedirectResult("/Content/seeyouthere.html");
            }
            else
            {
                return new RedirectResult("/Content/sorryyoucantcome.html");
            }
        }

        IResult IPresenter<IEnumerable<GuestResponse>>.GetResult()
        {
            return new DataResult<IEnumerable<GuestResponse>>(Repository.GetAllResponses());
        }

        IResult IPresenter<IEnumerable<GuestResponse>>.GetResult(IEnumerable<GuestResponse> requestData)
        {
            throw new System.NotImplementedException();
        }
    }
}