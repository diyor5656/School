﻿using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using School.Application.Exceptions;
using School.Application.Extensions;
using School.Application.Models;
using School.Application.Models.TodoList;
using School.Core.Entities;
using School.DataAccess.Repositories;
using School.Shared.Services;

namespace School.Application.Services.Impl;

public class TodoListService : ITodoListService
{
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    private readonly ITodoListRepository _todoListRepository;
    private readonly IMemoryCache _memoryCache;

    public TodoListService(ITodoListRepository todoListRepository, IMapper mapper, IClaimService claimService, IMemoryCache memoryCache)
    {
        _todoListRepository = todoListRepository;
        _mapper = mapper;
        _claimService = claimService;
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<TodoListResponseModel>> GetAllAsync()
    {
        var currentUserId = _claimService.GetUserId();

        var todoLists = await _todoListRepository.GetAllAsync(tl => tl.CreatedBy == currentUserId);

        return _mapper.Map<IEnumerable<TodoListResponseModel>>(todoLists);
    }

    #region IQueryable vs IEnumurable
    public async Task<List<TodoList>> GetAllWithIQueryableAsync()
    {
        IQueryable<TodoList> query = _todoListRepository.GetAll();
        query = query.OrderByDescending(a => a.Title); //order
        query = query.Take(1);
        int count = query.Count();
        var result = query.ToList();

        return result;
    }

    public List<TodoList> GetAllWithIEnumerable()
    {
        var query = _todoListRepository.GetAllAsEnumurable(); //select * from ;
        query = query.OrderByDescending(a => a.Title);
        query = query.Take(count: 1); //limit-1
        int count = query.Count(); //query to db
        var result = query.ToList();

        return result;
    }
    #endregion

    public async Task<CreateTodoListResponseModel> CreateAsync(CreateTodoListModel createTodoListModel)
    {
        var todoList = _mapper.Map<TodoList>(createTodoListModel);

        var addedTodoList = await _todoListRepository.AddAsync(todoList);

        return new CreateTodoListResponseModel
        {
            Id = addedTodoList.Id
        };
    }

    public async Task<UpdateTodoListResponseModel> UpdateAsync(Guid id, UpdateTodoListModel updateTodoListModel)
    {
        var todoList = await _todoListRepository.GetFirstAsync(tl => tl.Id == id);

        var userId = _claimService.GetUserId();

        if (userId != todoList.CreatedBy)
            throw new BadRequestException("The selected list does not belong to you");

        todoList.Title = updateTodoListModel.Title;

        return new UpdateTodoListResponseModel
        {
            Id = (await _todoListRepository.UpdateAsync(todoList)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var todoList = await _todoListRepository.GetFirstAsync(tl => tl.Id == id);

        return new BaseResponseModel
        {
            Id = (await _todoListRepository.DeleteAsync(todoList)).Id
        };
    }

    #region Pagination ,Cashing,AutomAppet.ProjectTo();
    public async Task<PagedResult<TodoList>> GetAllAsync(Options options)
    {
        var query = _todoListRepository.GetAll();

        var result = await query.ToPagedResultAsync(options);

        return result;
    }

    public async Task<PagedResult<TodoListResponseModel>> GetAllDTOAsync(Options options)
    {
        var cachedRsult = _memoryCache.Get<PagedResult<TodoListResponseModel>>("GetAllDTOAsync");

        if (cachedRsult is not null)
            return cachedRsult;

        var query = _todoListRepository.GetAll();

        var result = await query.ToPagedResultAsync<TodoList, TodoListResponseModel>(options, _mapper);
        var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);

        _memoryCache.Set("GetAllDTOAsync", result, expirationTime);

        return result;
    }
    #endregion
}
