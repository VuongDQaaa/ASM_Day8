using ASM_Day8.DTO;
using ASM_Day8.Entities;

namespace ASM_Day8.Utilities
{
    public static class Utility
    {
        public static ToDoTask DTOToEntity(this DTOTask dto)
        {
            return new ToDoTask() { Title = dto.Title, IsCompleted = dto.IsCompleted };
        }
    }
}