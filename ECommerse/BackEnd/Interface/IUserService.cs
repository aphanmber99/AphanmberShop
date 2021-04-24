using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.ViewModel;

namespace BackEnd.Interface
{
    public interface IUserService
    {
        Task<List<UserVM>> GetList();
    }
}