using backend.Entities.Entities;


namespace backend.Data.Interfaces
{
    public interface IGroupRepository : IGetById<Group>, IGetAll<Group>, ISave<Group>, IUpdate<Group>, IDelete<int>
    {
    }
}
