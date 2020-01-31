using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataLayer;
using TaskManager.Entities;

namespace TaskManager.BusinessLayer
{
   public class UserBAO
    {


    public List<User> GetAllUsers()
    {

        TaskContext tstDb = new TaskContext();


        var user = from usr in tstDb.Users
                    select usr;
        List<User> users = new List<User>();

        foreach (var item in user)
        {
            User u = new User();
            u.UserId = item.UserId;
            u.FirstName = item.FirstName;
            u.LastName = item.LastName;
            u.EmployeeId = item.EmployeeId;
         
            users.Add(u);
        }


        return users;

    }

        
    public User GetUserById(int userId)
    {
        TaskContext tstDb = new TaskContext();
        var user = from usr in tstDb.Users
                    where usr.UserId == userId
                    select usr;
        User u  = new User();
        foreach (var item in user)
        {

            u.UserId = item.UserId;
            u.FirstName = item.FirstName;
            u.LastName = item.LastName;
            u.EmployeeId = item.EmployeeId;
          

        }

        return u;

    }

    public int AddUser(User user)
    {
        TaskContext tstDb = new TaskContext();

        User u = new User();
            
        u.FirstName = user.FirstName;
        u.LastName = user.LastName;
        u.EmployeeId = user.EmployeeId;
    
        tstDb.Users.Add(u);
        int Retval = tstDb.SaveChanges();
        return Retval;



    }

    public int UpdateUser(int userId, User user)
    {
        TaskContext tstDb = new TaskContext();
        User u = tstDb.Users.Find(userId);

        u.FirstName = user.FirstName;
        u.LastName = user.LastName;
        u.EmployeeId = user.EmployeeId;
           

        tstDb.Entry(u).State = EntityState.Modified;
        int Retval = tstDb.SaveChanges();
        return Retval;
    }
    public int DeleteUser(int userId)
    {
        TaskContext tstDb = new TaskContext();
            User u = tstDb.Users.Find(userId);
        tstDb.Users.Remove(u);
        int Retval = tstDb.SaveChanges();
        return Retval;

    }   
    }
}
