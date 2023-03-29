using MasterOfCoinsAPI.Interfaces;
using MasterOfCoinsAPI.Models;
using System.Collections.Generic;
using System.Data;

namespace MasterOfCoinsAPI.Repositories
{
    public class GroupDetailsRepository : BaseRepository<GroupDetails>,IGroupDetailsRepository
    {
        public GroupDetailsRepository(IDbConnection connection): base(connection)
        {

        }
        public void Create(GroupDetails entity)
        {
            var query = "insert into GroupDetails(Name, Description) values (@Name, @Description)";
            var parameters = new
            {
                Name = entity.Name,
                Description = entity.Description
            };
            base.Execute(query, parameters);
        }

        public bool Delete(int id)
        {
            var query = "delete from GroupDetails where Id = @Id";
            return base.Execute(query, new { Id = id });
        }

        public List<GroupDetails> GetAll()
        {
            var query = "select * from GroupDetails";
            return base.GetAll(query);
        }

        public GroupDetails GetById(int id)
        {
            var query = "select * form GroupDetails where Id = @Id";
            return base.GetById(query, new { Id = id});
        }

        public void Update(GroupDetails entity)
        {
            var query = "update GroupDetails set Name = @Name, Description = @Description where Id = @Id";
            base.Execute(query, new { Name = entity.Name, Description = entity.Description, Id = entity.Id });
        }
    }
}
