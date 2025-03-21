﻿using assessment_backend_aspdotnet.CustomConfig;
using assessment_backend_aspdotnet.DataAccess.Entities;
using assessment_backend_aspdotnet.DataAccess.Repositories.StudentRepository;
using assessment_backend_aspdotnet.Interfaces.Manager;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Model.Dto;
using assessment_backend_aspdotnet.Model.Response;
using AutoMapper;
using static assessment_backend_aspdotnet.CustomConfig.UserDefinedException;

namespace assessment_backend_aspdotnet.Managers.ClassManager
{
    public class ClassManager : IClassManager
    {
        private readonly IMapper _mapper;
        private readonly IClassRepository _classRepository;
        private readonly IStudentRepository _studentRepository;
        public ClassManager(IMapper mapper, IClassRepository classRepository, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _classRepository = classRepository;
            _studentRepository = studentRepository;
        }

        public async Task<BaseResponse<ClassResponseDto>> AddClass(ClassDto cls)
        {
            ClassDto newClass = new ClassDto
            {
                Name = cls.Name,
                Grade = cls.Grade,
            };

            ClassDto result = await _classRepository.AddClass(newClass);

            ClassResponseDto responseData = _mapper.Map<ClassResponseDto>(result);

            return new BaseResponse<ClassResponseDto>
            {
                Success = true,
                Message = "Class Created",
                Data = responseData
            };
        }

        public async Task<BaseResponse<ClassResponseDto>> UpdateClass(int id, ClassDto cls)
        {
            ClassResponseDto? existingClass = await _classRepository.GetClassById(id);

            if (existingClass == null)
            {
                throw new UDNotFoundException("Class ID Not Found");
            }

            ClassDto newClass = new ClassDto
            {
                Name = cls.Name,
                Grade = cls.Grade
            };

            ClassDto result = await _classRepository.UpdateClass(id, newClass);

            ClassResponseDto responseData = _mapper.Map<ClassResponseDto>(result);

            return new BaseResponse<ClassResponseDto>
            {
                Success = true,
                Message = "Student Updated",
                Data = responseData
            };
        }
        public async Task<BaseResponse<bool>> DeleteClassById(int id)
        {
            bool responseData = await _classRepository.DeleteClassById(id);

            return new BaseResponse<bool>
            {
                Success = true,
                Message = "Class Removed",
                Data = responseData
            };
        }
        public async Task<BaseResponse<ClassResponseDto>> GetClassById(int id)
        {
            ClassResponseDto? responseData = await _classRepository.GetClassById(id);

            if (responseData == null) 
            {
                throw new UDNotFoundException("Class ID Not Found");
            }

            return new BaseResponse<ClassResponseDto>
            {
                Success = true,
                Message = "Class Recieved",
                Data = responseData
            };
        }

        public async Task<BaseResponse<PaginatedClassResponseDto>> GetAllClasses(string? name, int? pageNo, int? pageSize)
        {
            string nameFilter = name ?? string.Empty;

            PaginatedClassResponseDto responseData = await _classRepository.GetAllClasses(name, pageNo, pageSize);

            return new BaseResponse<PaginatedClassResponseDto>
            {
                Success = true,
                Message = "Classes Received",
                Data = responseData
            };
        }

        public async Task<BaseResponse<List<StudentResponseDto>>> GetStudentsByClassId(int id)
        {
            List<StudentResponseDto> responseData = await _studentRepository.GetStudentsByClassId(id);

            return new BaseResponse<List<StudentResponseDto>>
            {
                Success = true,
                Message = "Students Received",
                Data = responseData
            };
        }
    }
}
