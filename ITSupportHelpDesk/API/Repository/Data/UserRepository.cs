using API.Context;
using API.Helper;
using API.Model;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class UserRepository : GeneralRepository<MyContext, User, int>
    {
        private readonly MyContext myContext;
        private readonly DbSet<RegisterVM> entities;
        public IConfiguration Configuration;

        public UserRepository(MyContext myContext,IConfiguration configuration) : base(myContext)
        {
            this.myContext = myContext;
            entities = myContext.Set<RegisterVM>();
            Configuration = configuration;
        }

        public int Register(RegisterVM registerVM)
        {
            //var hashPassword = HashGenerator.HashPassword(registerVM.Password);
            var result = 0;
            var checkEmail = myContext.Users.FirstOrDefault(u => u.Email == registerVM.Email);
            var checkPhone = myContext.Users.FirstOrDefault(u => u.Phone == registerVM.Phone);
            if (checkEmail == null && checkPhone == null)
            {
                User user = new User
                {
                    Name = registerVM.Name,
                    Email = registerVM.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password),
                    BirthDate = registerVM.BirthDate,
                    gender = (User.Gender)registerVM.gender,
                    RoleId = 1,
                    Phone = registerVM.Phone,
                    Address = registerVM.Address,
                    Department = registerVM.Department,
                    Company = registerVM.Company
                };
                myContext.Add(user);
                result = myContext.SaveChanges();

                return result;
            }
            else if (checkEmail != null)
            {
                return 100;
            }
            else if (checkPhone != null)
            {
                return 200;
            }
            return result;
        }

        //public IEnumerable<LoginVM> GetLoginVMs()
        //{
        //    var getLoginVMs = (from u in myContext.Users
        //                       select new LoginVM
        //                       {
        //                           // NIK=p.NIK,
        //                           Email = u.Id,
        //                           Password = u.Password
        //                       }).ToList();


        //    if (getLoginVMs.Count == 0)
        //    {
        //        return null;
        //    }
        //    return getLoginVMs.ToList();
        //}

        public int Login(LoginVM login)
        {
            //ForgotPasswordVM forgotPassword = new ForgotPasswordVM();

            var cek = myContext.Users.FirstOrDefault(u => u.Email == login.Email);
            if (cek == null)
            {
                return 404;
            }

            if (BCrypt.Net.BCrypt.Verify(login.Password, cek.Password))
            {
                return 1;
            }
            else
            {
                return 401;
            }
        }
        public string GenerateTokenLogin(LoginVM loginVM)
        {
            var user = myContext.Users.FirstOrDefault(u => u.Email == loginVM.Email);
            var ar = myContext.Roles.Single(r => r.Id == user.RoleId);
            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, Configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Email", user.Email),
                    new Claim("role",ar.Name)
                    //new Claim(ClaimTypes.Role,ar.Role.RoleName)
                   };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                Configuration["Jwt:Issuer"],
                Configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
