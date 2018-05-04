﻿using ForumApplication.ServiceLayer.AccountService;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumApplication.WEB.Models;
using AutoMapper;
using ForumApplication.DataTransferObjects;

namespace ForumApplication.WEB.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class AdministratorController : Controller
    {
        IAccountService _accountService;
        IAuthenticationManager _authenticationManager;

        public AdministratorController(IAccountService accountService, IAuthenticationManager authManager)
        {
            _accountService = accountService;
            _authenticationManager = authManager;
        }

        // GET: Adninistrator

        [HttpGet]
        public ActionResult UserManager()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UserLists(int jtStartIndex = 0, int jtPageSize = 10)
        {
            var userAccountDto = _accountService.GetUserAccountsListForJTable(jtStartIndex, jtPageSize);

            var usersAccountsJTableViewModel = Mapper.Map<ICollection<TableAccountInfoViewModel>>(userAccountDto);


            return Json(new { Result = "OK", Records = usersAccountsJTableViewModel, TotalRecordCount = _accountService.CountUserAccounts });
        }

        [HttpPost]
        public JsonResult DeleteAccount(string Id)
        {
            _accountService.DisableAccount(Id);

            return Json(new { Result = "OK" });
        }

        [HttpPost]
        public JsonResult CreateAccount(TableCreateAccountViewModel newAccountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again" });
            }

                switch (newAccountViewModel.RoleName)
                {
                    case "User":
                        newAccountViewModel.Image = "941f3690-6f0d-4752-a289-3e3fcdc91fcatroglodyte.png";
                        break;

                    case "Moderator":
                        newAccountViewModel.Image = "0420aa0c-52f0-4510-904f-9e99be42fb2aknight.png";
                        break;
                    default:
                        newAccountViewModel.Image = "941f3690-6f0d-4752-a289-3e3fcdc91fcatroglodyte.png";
                        break;
                }
                var JTableCreatUserAccountDto = Mapper.Map<JtableCreateAccountDto>(newAccountViewModel);
                var createResult = _accountService.CreateUserAccount(JTableCreatUserAccountDto);

                if (createResult.Succeeded)
                {
                    var newUser = JTableCreatUserAccountDto;
                    return Json(new { Result = "OK", Record = newUser });
                }
                else
                {
                    return Json(new { Result = "ERROR", Message = createResult.Errors });
                }
            }
            
        


        [HttpPost]
        public JsonResult UpdateAccount(TableUpdateAccountViewModel updateAccountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again" });
            }


            var updateAccountDto = Mapper.Map<JtableUpdateAccountDto>(updateAccountViewModel);

            _accountService.UpdateUserProfile(updateAccountDto);
            return Json(new
            {
                Result = "OK"
            });
        }
    }
}