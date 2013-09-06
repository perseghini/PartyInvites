using System.Collections.Generic;
using Ninject;
using PartyInvites.Models;
using PartyInvites.Models.Repository;
using PartyInvites.Presenters;

namespace PartyInvites.App_Start
{
    public static class DIConfiguration
    {
        public static void SetupDI(IKernel kernel)
        {
            kernel.Bind<IPresenter<GuestResponse>>().To<RsvpPresenter>();
            kernel.Bind<IPresenter<IEnumerable<GuestResponse>>>().To<RsvpPresenter>();
            kernel.Bind<IRepository>().To<MemoryRepository>().InSingletonScope();
        }
    }
}