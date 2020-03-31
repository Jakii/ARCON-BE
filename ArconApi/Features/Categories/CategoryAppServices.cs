using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArconApi.Common;
using ArconApi.Data;
using ArconApi.Data.Models;
using ArconApi.Feature.Category;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Features.Categories{
    public class CategoryAppServices : IDisposable
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryAppServices(IGenericRepository<Category> categoryRepository,IMapper mapper)
        {
            this._categoryRepository=categoryRepository;
            this._mapper = mapper;
        }

        public async Task<Response> GetAll()
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAllAsyn();
           if(categories!=null && categories.Any())
           {
                return new Response { Data =  _mapper.Map<IEnumerable<CategoryDto>>(categories)
                 };
           }else 
           {
               return new Response{ Message="La lista de categorias esta vacia"};
           }

        }

        public async Task<ActionResult<Response>> Create(CategoryDto request)
        {
            Category newCategory= new Category.Builder(request.CategoryName)
            .WithIsActive(request.IsActive)
            .Build();
            await _categoryRepository.AddAsyn(newCategory);
            await _categoryRepository.SaveAsync();
            return new Response { Data = _mapper.Map<CategoryDto>(newCategory) };
        }

         public async Task<Response> Update(int id, CategoryDto request)
        {
            Category categoryFind = await _categoryRepository.GetAsync(id);
            if (categoryFind == null)
            {
                return new Response { Message = " No existe catgoria con el Id: " + id};
            }

           categoryFind.SetCategoryName(request.CategoryName);
           categoryFind.SetIsActive(request.IsActive);
            await _categoryRepository.SaveAsync();

            return new Response { Data = _mapper.Map<CategoryDto>(categoryFind) };
        }
         public async Task<Response> Disable(int id)
        {
            Category categoryFind = await _categoryRepository.GetAsync(id);
            if (categoryFind == null)
            {
                return new Response { Message = " No existe categoria con el Id" };
            }

            categoryFind.SetIsActive(0);
            await _categoryRepository.SaveAsync();
             return new Response { Data = _mapper.Map<CategoryDto>(categoryFind) };

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                
                _categoryRepository.Dispose();
            }
        }
    }
}