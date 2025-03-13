﻿using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;

namespace assessment_backend_aspdotnet.Interfaces.Repository
{
    public interface IClassRepository
    {
        Task<ClassDto> AddClass(ClassDto cls);
        Task<ClassResponseDto?> GetClassById(int id);
        Task<List<ClassResponseDto>> GetAllClasses();



    }
}
