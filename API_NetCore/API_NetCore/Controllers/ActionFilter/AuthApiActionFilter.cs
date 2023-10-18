using API_NetCore.Common.Provider;
using API_NetCore.Models.Entitiess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OKEA.Library.Common.Providers;
using OKEA.Library.Models.Cache;
using OKEA.Library.Models.Enums;
using OKEA.Library.Models.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API_NetCore.Common.Constants;

namespace OKEA.Service.Main.API.ActionFilter
{
    public class AuthApiActionFilter : IAsyncActionFilter, IOrderedFilter
    {
        public int Order => int.MinValue;
        private readonly CacheProvider _cacheProvider;
        private readonly OKEAContext _context;
        public AuthApiActionFilter(CacheProvider cacheProvider,OKEAContext context)
        {
            _cacheProvider = cacheProvider;
            _context = context;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            var allowAnonymousAttribute = filterContext.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().FirstOrDefault();
            var isSupperAdmin = false;
            var isAdmin = false;

            if (allowAnonymousAttribute == null)
            {
                filterContext.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorizationToken);
                var tokenString = Convert.ToString(authorizationToken);
                if (string.IsNullOrEmpty(tokenString))
                {
                    filterContext.Result = new UnauthorizedResult();
                    return;
                }

                tokenString = tokenString.Replace("Bearer ", "");

                if (tokenString.StartsWith(Cookies.KeyAdmin))
                {
                    var adminCache = (AdminCache)_cacheProvider.Get(tokenString);

                    if (adminCache == null)
                    {
                        // cannot find in memory cache, try search in database
                        var adminCacheFromDb = await _context.AccountTokens.FirstOrDefaultAsync(u => u.Token == tokenString); 

                        if (adminCacheFromDb == null || adminCacheFromDb.ExpiredAt < DateTime.Now)
                        {
                            filterContext.Result = new UnauthorizedResult();
                            return;
                        }

                        // save user information into mem cache
                        var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Id == adminCacheFromDb.AccountId); 

                        if (admin == null)
                        {
                            filterContext.Result = new UnauthorizedResult();
                            return;
                        }

                        adminCache = new AdminCache()
                        {
                            AdminId = adminCacheFromDb.AccountId,
                            LoginName = admin.LoginName,
                            FullName = admin.FullName,
                            Email = admin.Email,
                            IsSupperAdmin = (admin.AdminRole == 1)
                        };
                    }

                    // save data into RouteData
                    filterContext.RouteData.Values.Add(Regular.CurrentUserAdminKey, adminCache);
                    //var expireTime = DateTime.Now.AddHours(Regular.TokenExpireTime);
                    //_cacheProvider.Set(tokenString, adminCache, expireTime);
                    isAdmin = true;

                    if (adminCache.IsSupperAdmin)
                    {
                        isSupperAdmin = true;
                    }
                }
                else if (tokenString.StartsWith(Cookies.KeyUser))
                {
                    var userCache = (UserCache)_cacheProvider.Get(tokenString);

                    if (userCache == null)
                    {
                        var userCacheFromDb = await _context.AccountTokens.FirstOrDefaultAsync(u => u.Token == tokenString);

                        if (userCacheFromDb == null || userCacheFromDb.ExpiredAt < DateTime.Now)
                        {
                            filterContext.Result = new UnauthorizedResult();
                            return;
                        }

                        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userCacheFromDb.AccountId);
                        
                        if (user == null || !user.IsActived)
                        {
                            filterContext.Result = new UnauthorizedResult();
                            return;
                        }

                        var departmentUsers = await _context.DepartmentUsers.Where(u =>  u.UserId == user.Id ).ToListAsync();
                        var department = await _context.Departments.FirstOrDefaultAsync(u =>u.Id == user.DepartmentId.Value);
                        var DepartmentUserCaches = new List<DepartmentUserCache>();
                        var isManager = false;
                        if (departmentUsers != null &&  departmentUsers.Any())
                        {
                            foreach (var departmentUser in departmentUsers)
                            {
                                var departmentFind = await _context.Departments.FirstOrDefaultAsync(d => d.Id == departmentUser.DepartmentId);
                                if (departmentUser.IsManager.HasValue && !isManager)
                                {
                                    isManager = true;
                                }
                                DepartmentUserCache dpmUser = new DepartmentUserCache()
                                {
                                    DepartmentId = departmentUser.DepartmentId,
                                    DepartmentName = departmentUser.DepartmentName,
                                    UserRoleId = departmentUser.UserRoleId,
                                    UserRoleName = departmentUser.UserRoleName,
                                    IsManager = departmentUser.IsManager,
                                    ParentId = departmentFind?.ParentId,
                                    DepartmentStructure = departmentUser.DepartmentStructure
                                };

                                DepartmentUserCaches.Add(dpmUser);
                            }
                        }

                        userCache = new UserCache()
                        {
                            UserId = user.Id,
                            CurrentStar = user.CurrentStar,
                            Email = user.Email,
                            FullName = user.FullName,
                            Gender = (Gender)user.Gender,
                            UserRole = user.UserRole,
                            DepartmentId = user.DepartmentId,
                            DepartmentName = user.DepartmentName,
                            DepartmentUserJson = JsonConvert.SerializeObject(DepartmentUserCaches),
                            IsManager = isManager,
                            DepartmentStructure = department != null && department.DepartmentStructure != null ? department.DepartmentStructure : ""
                        };
                    }

                    // save data into RouteData
                    filterContext.RouteData.Values.Add(Regular.CurrentUserCustomerKey, userCache);
                    //var expireTime = DateTime.Now.AddHours(Regular.TokenExpireTime);
                    //_cacheProvider.Set(tokenString, userCache, expireTime);
                }
                else
                {
                    filterContext.Result = new UnauthorizedResult();
                    return;
                }
            }

            var authAdminAttribute = filterContext.ActionDescriptor.EndpointMetadata.OfType<AuthAdminAttribute>().FirstOrDefault();
            var authSupperAdminAttribute = filterContext.ActionDescriptor.EndpointMetadata.OfType<AuthSuperAdminAttribute>().FirstOrDefault();

            if (authAdminAttribute != null && !isAdmin && allowAnonymousAttribute == null)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            if (authSupperAdminAttribute != null && !isSupperAdmin && allowAnonymousAttribute == null)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        private class AuthAdminAttribute
        {
        }
    }
}
