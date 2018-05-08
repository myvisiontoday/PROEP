using IManageService.BusinessLogic.Domain;

namespace IManageService.BusinessLogic.Repostiories
{
    /// <summary>
    /// An interface for a class providing capabilities to perform CRUD in Items entity 
    /// </summary>
    public interface IItemRepository : IRepository<Item>
    {

    }
}
