// using Library.Data.Auth;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using Microsoft.AspNetCore.Authorization;
// using System.Security.Claims;
// using System.Text;
// using System.Security.Cryptography;
// using Library.Data.Entities;

// namespace LibraryWebAPI.Services
// {
//     public class AuthenticateService : IAuthenticateService
//     {
//         private readonly UserManager<ApplicationUser> _userManager;
//         private readonly RoleManager<IdentityRole> _roleManager;
//         private readonly IConfiguration _configuration;

//         public AuthenticateService(
//             UserManager<ApplicationUser> userManager,
//             RoleManager<IdentityRole> roleManager,
//             IConfiguration configuration
//         )
//         {
//             _userManager = userManager;
//             _roleManager = roleManager;
//             _configuration = configuration;
//         }

//         public async Task<LoginModel> Login(LoginModel model)
//         {
//             if (!string.IsNullOrEmpty(model.Username) && string.IsNullOrEmpty(model.Password))
//             {
//                 return null;
//             }

//             var user = await _userManager.FindByNameAsync(model.Username);

//             if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
//             {
//                 var userRoles = await _userManager.GetRolesAsync(user);

//                 var authClaims = new List<Claim>
//                 {
//                     new Claim(ClaimTypes.Name, user.UserName),
//                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                 };

//                 foreach (var userRole in userRoles)
//                 {
//                     authClaims.Add(new Claim(ClaimTypes.Role, userRole));
//                 }

//                 var token = CreateToken(authClaims);
//                 var refreshToken = GenerateRefreshToken();

//                 _ = int.TryParse(
//                     _configuration["JWT:RefreshTokenValidityInDays"],
//                     out int refreshTokenValidityInDays
//                 );

//                 user.RefreshToken = refreshToken;
//                 user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

//                 await _userManager.UpdateAsync(user);

//                 return 
//                     new
//                     {
//                         Token = new JwtSecurityTokenHandler().WriteToken(token),
//                         RefreshToken = refreshToken,
//                         Expiration = token.ValidTo
//                     }
//                 ;
//             }
//             return null;
//         }

//         public Task Add()
//         {
//             throw new NotImplementedException();
//         }

//         public Task<IEnumerable<Person>> Get()
//         {
//             throw new NotImplementedException();
//         }

//         // private LibraryContext _context;

//         // public LibraryService(LibraryContext context)
//         // {
//         //     _context = context;
//         // }

//         // public async Task<IEnumerable<Person>> Get()
//         // {
//         //     var people = await _context.People.ToListAsync();
//         //     return people;
//         // }

//         // public async Task Add()
//         // {
//         //     var p = new Person()
//         //     {
//         //         Name = "David",
//         //         Age = 22,
//         //         Dob = DateTime.Now,
//         //         Gender = Common.Enums.GenderEnum.Male,
//         //         EmailAddress = "Library@gmail.com",
//         //         LicenseId = "license to kill"
//         //     };
//         //     await _context.People.AddAsync(p);
//         //     await _context.SaveChangesAsync();
//         // }
//     }
// }
