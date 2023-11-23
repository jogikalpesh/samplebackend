using backend.Entities.Entities;


namespace backend.Data.Interfaces
{
    public interface IMemberRepository : IGetById<Member>, IGetAll<Member>, ISave<Member>, IUpdate<Member>, IDelete<int>
    {
    }
}
