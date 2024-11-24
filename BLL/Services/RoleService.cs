using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IRoleService
    {
        public IQueryable<RoleModel> Query();
        public ServiceBase Create(Role record);
        public ServiceBase Update(Role record);
        public ServiceBase Delete(int id);
    }
    
    public class RoleService : ServiceBase, IRoleService
    {
        public RoleService(Db db) : base(db)
        {
        }

        public IQueryable<RoleModel> Query()
        {
            return _db.Roles.OrderBy(r => r.Name).Select(r => new RoleModel() { Record = r });
        }

        public ServiceBase Create(Role record)
        {
            if (_db.Roles.Any(r => r.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Roles with the same name already exists.");
            record.Name = record.Name?.Trim();
            record.Description = record.Description?.Trim();
            _db.Roles.Add(record);
            _db.SaveChanges(); //commit to the database
            return Success("Role Created Successfully.");
        }

        public ServiceBase Update(Role record)
        {
            if (_db.Roles.Any(r => r.Id != record.Id && r.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Roles with the same name already exists.");
            var entity = _db.Roles.SingleOrDefault(r => r.Id == record.Id);
            if (entity is null)
                return Error("Role Not Found.");
            entity.Name = record.Name?.Trim();
            entity.Description = record.Description?.Trim();
            _db.Roles.Update(entity);
            _db.SaveChanges();
            return Success("Role Updated Successfully.");
            
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Roles.Include(r => r.Users).SingleOrDefault(r => r.Id == id);
            if (entity is null)
                return Error("Role Not Found.");
            if (entity.Users.Any())
                return Error("Role has relational users.");
            _db.Roles.Remove(entity);
            _db.SaveChanges();
            return Success("Role Deleted Successfully.");
        }
    }
}