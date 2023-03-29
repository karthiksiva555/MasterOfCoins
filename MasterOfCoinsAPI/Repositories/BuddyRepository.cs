using MasterOfCoinsAPI.Interfaces;
using MasterOfCoinsAPI.Models;
using System.Collections.Generic;
using System.Data;

namespace MasterOfCoinsAPI.Repositories
{
    public class BuddyRepository : BaseRepository<Buddy>, IBuddyRepository
    {
        public BuddyRepository(IDbConnection connection):base(connection)
        {
            
        }

        public void Create(Buddy entity)
        {
            var query = "insert into Buddy(LastName, FirstName, BirthDate, Email, PhoneNumber) " +
                "values (@LastName, @FirstName, @BirthDate, @Email, @PhoneNumber)";
            var parameters = new
            {
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                BirthDate = entity.BirthDate,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber
            };
            base.Execute(query, parameters);
        }

        public bool Delete(int id)
        {
            var query = "delete from Buddy where Id = @BuddyId";
            return base.Execute(query, new { BuddyId = id });
        }

        public List<Buddy> GetAll()
        {
            var query = "select * from Buddy";
            return base.GetAll(query);
        }

        public Buddy GetById(int id)
        {
            var query = "select * from Buddy where Id = @BuddyId";
            return base.GetById(query, new { BuddyId = id });
        }

        public void Update(Buddy entity)
        {
            var query = "update Buddy set LastName= @LastName, FirstName = @FirstName, BirthDate = @BirthDate, Email = @Email, " +
                "PhoneNumber = @PhoneNumber where Id = @BuddyId";
            var parameters = new
            {
                BuddyId = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                BirthDate = entity.BirthDate,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber
            };
            base.Execute(query, parameters);
        }
    }
}
