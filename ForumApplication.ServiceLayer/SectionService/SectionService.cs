﻿using ForumApplication.DataLayer.Interfaces;
using ForumApplication.DataLayer.Repository.CustomRepository;
using ForumApplication.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumApplication.Domain.Entitys;

namespace ForumApplication.ServiceLayer.SectionService
{
    public class SectionService : ISectionService
    {
        ISectionRepository _repo;
        public SectionService( ISectionRepository repository)
        {
            _repo = repository;
        }

        public void CreateSection(BaseForumContainerInfoDto item)
        {
            throw new NotImplementedException();
        }

        public void CreateSectionList(BaseForumContainerInfoDto item)
        {
            var ForumElement = Mapper.Map<Section>(item);
            ForumElement.DateCreated = DateTime.Now;
            ForumElement.DateUpdate = DateTime.Now;

            _repo.AddNewItem(ForumElement);
        }

        public void DeleteSection(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSectionList(int id)
        {
            throw new NotImplementedException();
        }

        public IList<BaseForumContainerInfoDto> GetAllElements()
        {
           
            var SectionList = _repo.GetAllIncludeReferences();

            return Mapper.Map<IList<BaseForumContainerInfoDto>>(SectionList);
        }

        public BaseForumContainerInfoDto GetElement(int id)
        {
            
            var SectionElement = _repo.GetByIDIncludeReferences(id);

            return Mapper.Map<BaseForumContainerInfoDto>(SectionElement);
        }

        //public void UpdateSection(UpdateBaseForumDto updateSection)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
