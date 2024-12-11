using School.Application.Models;
using School.Application.Models.TodoList;
using School.Core.Entities;

namespace School.Application.Services;

public interface ITodoListService
{
    Task<CreateTodoListResponseModel> CreateAsync(CreateTodoListModel createTodoListModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<TodoListResponseModel>> GetAllAsync();
    Task<List<TodoList>> GetAllWithIQueryableAsync();
    List<TodoList> GetAllWithIEnumerable();
    Task<PagedResult<TodoList>> GetAllAsync(Options options);
    Task<PagedResult<TodoListResponseModel>> GetAllDTOAsync(Options options);
    Task<UpdateTodoListResponseModel> UpdateAsync(Guid id, UpdateTodoListModel updateTodoListModel);
}
