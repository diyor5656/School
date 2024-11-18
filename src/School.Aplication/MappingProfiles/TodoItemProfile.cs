using AutoMapper;
using School.Application.Models.TodoItem;
using School.Core.Entities;

namespace School.Application.MappingProfiles;

public class TodoItemProfile : Profile
{
    public TodoItemProfile()
    {
        CreateMap<CreateTodoItemModel, TodoItem>()
            .ForMember(ti => ti.IsDone, ti => ti.MapFrom(cti => false));

        CreateMap<UpdateTodoItemModel, TodoItem>();

        CreateMap<TodoItem, TodoItemResponseModel>();
    }
}
