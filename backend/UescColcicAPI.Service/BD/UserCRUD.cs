
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace UescColcicAPI.Services.BD;

public class UserCRUD : IUserCRUD
{
    private UescColcicDBContext _context;
    public UserCRUD(UescColcicDBContext context){
        _context = context;
    }
    public void Create(User entity)
    {   
        _context.User.Add(entity);
        _context.SaveChanges();

    }

    public void Delete(User entity)
    {   
        var User = this.ReadById(entity.IdUser);
        if(User != null){
            _context.User.Remove(User);
            _context.SaveChanges();
        }
    }

   public IEnumerable<User> ReadAll()
    {
        return _context.User.ToList();
    }

    public User? ReadById(int id)
    {
        var User = _context.User.FirstOrDefault(p => p.IdUser == id);
        return User;
    }
    public User? ReadByUserName(String UserName)
    {
        var User = _context.User.FirstOrDefault(p => p.UserName == UserName);
        return User;
    }

    public void Update(User entity)
    {
        var User = this.ReadById(entity.IdUser);
        if(User is not null)
        {
            User.UserName = entity.UserName;
            User.Password= entity.Password;
            User.Rules = entity.Rules;
            _context.SaveChanges();
        }
    }

}



