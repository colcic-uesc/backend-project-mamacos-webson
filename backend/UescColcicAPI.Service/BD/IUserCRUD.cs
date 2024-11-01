using System;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD.Interfaces;
// Assina o contrato de CRUD, porém para classe User
public interface IUserCRUD : IBaseCRUD<User>
{
    public User? ReadByUserName(String UserName);
}
