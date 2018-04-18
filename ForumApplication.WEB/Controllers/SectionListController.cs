﻿using AutoMapper;
using ForumApplication.DataTransferObjects;
using ForumApplication.ServiceLayer.SectionListService;
using ForumApplication.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumApplication.WEB.Controllers
{
    public class SectionListController : Controller
    {
        ISectionListService _sectionListService;
        public SectionListController(ISectionListService sectionListService)
        {
            _sectionListService = sectionListService;
        }
        // GET: SectionList
        public ActionResult Item(int id)
        {
            var SecListItemDto = _sectionListService.GetElement(id);
            var SecListItemVieweModel = Mapper.Map<SectionListViewModel>(SecListItemDto);

            return View(SecListItemVieweModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(NewForumContainerModel containerModel)
        {
            var SecListContainerDto = Mapper.Map<SaveNewForumContainerDto>(containerModel);
            return View();
        }
    }
}