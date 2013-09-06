using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using PartyInvites.Models;
using PartyInvites.Models.Repository;
using PartyInvites.Presenters;
using PartyInvites.Presenters.Results;

namespace PartyInvites.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        public IPresenter<GuestResponse> Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter = new RsvpPresenter { Repository = new MemoryRepository() };
            if (IsPostBack)
            {
                GuestResponse rsvp = ((DataResult<GuestResponse>)Presenter.GetResult()).DataItem;

                if (TryUpdateModel(rsvp, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    Response.Redirect(((RedirectResult)Presenter.GetResult(rsvp)).Url);
                }
            }
        }
    }
}